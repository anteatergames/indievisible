using IndieVisible.Application.Interfaces;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var pollOption = pollOptionDomainService.GetById(pollOptionId);

            if (pollOption == null)
            {
                return new OperationResultVo("Unable to identify the poll you are voting for.");
            }

            var poll = pollDomainService.GetById(pollOption.PollId);

            var userVotesOnThisPoll = pollVoteDomainService.Get(userId, poll.Id).ToList();

            var alreadyVoted = userVotesOnThisPoll.Any(x => x.PollOptionId == pollOptionId);

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
                var vote = userVotesOnThisPoll.FirstOrDefault();

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


            return new OperationResultVo(true);
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
