using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Poll;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Extensions;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace IndieVisible.Application.Services
{
    public class PollAppService : IPollAppService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPollDomainService pollDomainService;
        private readonly IGamificationDomainService gamificationDomainService;

        public PollAppService(IUnitOfWork unitOfWork
            , IPollDomainService pollDomainService
            , IGamificationDomainService gamificationDomainService)
        {
            this.unitOfWork = unitOfWork;
            this.pollDomainService = pollDomainService;
            this.gamificationDomainService = gamificationDomainService;
        }

        public OperationResultVo PollVote(Guid currentUserId, Guid pollOptionId)
        {
            try
            {
                int pointsEarned = 0;
                Poll poll = pollDomainService.GetPollByOptionId(pollOptionId);

                if (poll == null)
                {
                    return new OperationResultVo("Unable to identify the poll you are voting for.");
                }

                var option = poll.Options.First(x => x.Id == pollOptionId);
                option.Votes = option.Votes.SafeList();

                bool alreadyVoted = option.Votes.Any(x => x.UserId == currentUserId);

                if (alreadyVoted)
                {
                    return new OperationResultVo("You already voted on this option.");
                }

                var userVotesOnThisPoll = poll.Options.SelectMany(x => x.Votes.SafeList()).Where(x => x.UserId == currentUserId);

                if (poll.MultipleChoice || !userVotesOnThisPoll.Any())
                {
                    pollDomainService.AddVote(currentUserId, poll.Id, pollOptionId);
                }
                else
                {
                    var oldVote = userVotesOnThisPoll.FirstOrDefault();
                    if (oldVote != null)
                    {
                        pollDomainService.ReplaceVote(currentUserId, poll.Id, oldVote.PollOptionId, pollOptionId);
                    }
                }

                if (!userVotesOnThisPoll.Any())
                {
                    pointsEarned = gamificationDomainService.ProcessAction(currentUserId, PlatformAction.PollVote);
                }

                unitOfWork.Commit();

                PollResultsViewModel resultVm = CalculateNewResult(poll);

                return new OperationResultVo<PollResultsViewModel>(resultVm, pointsEarned);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        private PollResultsViewModel CalculateNewResult(Poll poll)
        {
            PollResultsViewModel resultVm = new PollResultsViewModel();

            IEnumerable<PollVote> votes = pollDomainService.GetVotes(poll.Id);

            IEnumerable<KeyValuePair<Guid, int>> groupedVotes = from v in votes
                                                                group v by v.PollOptionId into g
                                                                select new KeyValuePair<Guid, int>(g.Key, g.Count());

            int totalVotes = groupedVotes.Sum(x => x.Value);
            resultVm.TotalVotes = totalVotes;

            foreach (KeyValuePair<Guid, int> g in groupedVotes)
            {
                PollOptionResultsViewModel newOptionResult = new PollOptionResultsViewModel
                {
                    OptionId = g.Key,
                    VoteCount = g.Value,
                    Percentage = ((g.Value / (decimal)totalVotes) * 100).ToString("N2", new CultureInfo("en-us"))
                };

                resultVm.OptionResults.Add(newOptionResult);
            }

            return resultVm;
        }
    }
}
