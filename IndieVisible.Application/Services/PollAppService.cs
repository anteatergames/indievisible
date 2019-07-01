using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Poll;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
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
        private readonly IPollOptionDomainService pollOptionDomainService;
        private readonly IPollVoteDomainService pollVoteDomainService;

        public PollAppService(IUnitOfWork unitOfWork
            , IPollDomainService pollDomainService, IPollOptionDomainService pollOptionDomainService, IPollVoteDomainService pollVoteDomainService)
        {
            this.unitOfWork = unitOfWork;
            this.pollDomainService = pollDomainService;
            this.pollOptionDomainService = pollOptionDomainService;
            this.pollVoteDomainService = pollVoteDomainService;
        }

        public OperationResultVo PollVote(Guid userId, Guid pollOptionId)
        {
            PollOption pollOption = pollOptionDomainService.GetById(pollOptionId);

            if (pollOption == null)
            {
                return new OperationResultVo("Unable to identify the poll you are voting for.");
            }

            Poll poll = pollDomainService.GetById(pollOption.PollId);

            List<PollVote> userVotesOnThisPoll = pollVoteDomainService.Get(userId, poll.Id).ToList();

            bool alreadyVoted = userVotesOnThisPoll.Any(x => x.PollOptionId == pollOptionId);

            if (alreadyVoted)
            {
                return new OperationResultVo("You already voted on this option.");
            }

            if (poll.MultipleChoice)
            {
                AddVote(userId, pollOption, poll);
            }
            else
            {
                PollVote vote = userVotesOnThisPoll.FirstOrDefault();

                if (vote == null)
                {
                    AddVote(userId, pollOption, poll);
                }
                else
                {
                    UpdateVote(pollOptionId, vote);
                }
            }

            unitOfWork.Commit();

            PollResultsViewModel resultVm = CalculateNewResult(poll.Id);

            return new OperationResultVo<PollResultsViewModel>(resultVm);
        }

        private PollResultsViewModel CalculateNewResult(Guid pollId)
        {
            PollResultsViewModel resultVm = new PollResultsViewModel();

            IEnumerable<PollVote> votes = pollVoteDomainService.GetByPollId(pollId);

            IEnumerable<KeyValuePair<Guid, int>> groupedVotes = from v in votes
                                                                group v by v.PollOptionId into g
                                                                select new KeyValuePair<Guid, int>(g.Key, g.Count());

            var totalVotes = groupedVotes.Sum(x => x.Value);
            resultVm.TotalVotes = totalVotes;

            foreach (var g in groupedVotes)
            {
                var newOptionResult = new PollOptionResultsViewModel();
                newOptionResult.OptionId = g.Key;
                newOptionResult.VoteCount = g.Value;
                newOptionResult.Percentage = ((g.Value / (decimal)totalVotes) * 100).ToString("N2", new CultureInfo("en-us"));

                resultVm.OptionResults.Add(newOptionResult);
            }

            return resultVm;
        }

        private void UpdateVote(Guid pollOptionId, PollVote vote)
        {
            vote.PollOptionId = pollOptionId;

            pollVoteDomainService.Update(vote);
        }

        private void AddVote(Guid userId, PollOption pollOption, Poll poll)
        {
            PollVote newVote = new PollVote
            {
                UserId = userId,
                PollId = poll.Id,
                PollOptionId = pollOption.Id
            };

            pollVoteDomainService.Add(newVote);
        }
    }
}
