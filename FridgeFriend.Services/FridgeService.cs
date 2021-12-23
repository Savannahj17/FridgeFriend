using FridgeFriend.Data;
using FridgeFriend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFriend.Services
{
    public class FridgeService
    {
        private readonly Guid _userId;

        public FridgeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFridge(FridgeCreate model)
        {
            var entity =
                new Fridge()
                {
                    OwnerId = _userId,
                    FridgeId = model.FridgeId,
                    FridgeMake = model.FridgeMake,
                    FridgeModel = model.FridgeModel,
                    Nickname = model.Nickname,
                    Address = model.Address,
                    UserEmail = model.UserEmail
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Fridges.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FridgeListItem> GetFridges()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Fridges
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new FridgeListItem
                                {
                                    FridgeId = e.FridgeId,
                                    FridgeMake = e.FridgeMake,
                                    FridgeModel = e.FridgeModel,
                                    Nickname = e.Nickname
                                }
                        );

                return query.ToArray();
            }
        }
        public bool UpdateFridge(FridgeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Fridges
                        .Single(e => e.FridgeId == model.FridgeId && e.OwnerId == _userId);

                entity.FridgeMake = model.FridgeMake;
                entity.FridgeModel = model.FridgeModel;
                entity.Nickname = model.Nickname;
                entity.Address = model.Address;
                entity.UserEmail = model.UserEmail;
               

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteFridge(int fridgeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Fridges
                        .Single(e => e.FridgeId == fridgeId && e.OwnerId == _userId);

                ctx.Fridges.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
