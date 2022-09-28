using Microsoft.EntityFrameworkCore;
using MotorRepair.Repository.Abstracts;
using MotorRepair.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorRepair.Repository
{
  public class TicketRepository : ITicketRepository
  {
    private readonly ApplicationDbContext _dbContext;

    public TicketRepository(ApplicationDbContext dbContext) {
      _dbContext = dbContext;
    }

    public async Task<Ticket> Create(Ticket entity) {
      entity.CreatedDate = DateTime.UtcNow;
      entity.CreatedBy = "nguyen.tran@nowhere.com"; // TODO: implement auth

      var addedTicket = _dbContext.Tickets.Add(entity);      
      await _dbContext.SaveChangesAsync();

      return addedTicket.Entity;
    }

    public async Task<int> Delete(int id) {
      var ticketToDelete = await _dbContext.Tickets.FirstOrDefaultAsync(t => t.Id == id);
      if (ticketToDelete != null) {
        _dbContext.Tickets.Remove(ticketToDelete);

        return await _dbContext.SaveChangesAsync();
      }

      return 0;
    }

    public async Task<IEnumerable<Ticket>> GetAll() {
      return await _dbContext.Tickets.Include(t => t.WorkItems).ToListAsync();
    }

    public async Task<Ticket> GetById(int id) {
      var foundTicket = await _dbContext.Tickets.Include(t => t.WorkItems).FirstOrDefaultAsync(t => t.Id == id);

      return foundTicket ?? new Ticket();
    }

    public async Task<Ticket> Update(Ticket entity) {
      if (entity != null) {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
      }

      return entity;
    }
  }
}
