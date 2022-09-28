using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using MotorRepair.Repository.Abstracts;
using MotorRepair.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MotorRepair.Repository
{
  public class WorkItemRepository : IWorkItemRepository
  {
    private readonly ApplicationDbContext _dbContext;

    public WorkItemRepository(ApplicationDbContext dbContext) {
      _dbContext = dbContext;
    }
    public async Task<WorkItem> Create(WorkItem entity) {
      entity.CreatedDate = DateTime.UtcNow;
      entity.CreatedBy = "nguyen.tran@nowhere.com"; // TODO: implement auth
      var workItemToAdd = _dbContext.WorkItems.Add(entity);
      await _dbContext.SaveChangesAsync();

      return workItemToAdd.Entity;
    }

    public async Task<int> Delete(int id) {
      var workItemToDelete = await _dbContext.WorkItems.FirstOrDefaultAsync(wi => wi.Id == id);
      if (workItemToDelete != null) {
        _dbContext.WorkItems.Remove(workItemToDelete);

        return await _dbContext.SaveChangesAsync();
      }

      return 0;
    }

    public async Task<IEnumerable<WorkItem>> GetAll() {
      return await _dbContext.WorkItems.Include(w => w.Ticket).ToListAsync();
    }

    public async Task<WorkItem> GetById(int id) {
      var foundWorkItem = await _dbContext.WorkItems.Include(w => w.Ticket).FirstOrDefaultAsync(wi => wi.Id == id);

      return foundWorkItem ?? new WorkItem();
    }

    public async Task<IEnumerable<WorkItem>> GetByTicketId(int id) {
      return await _dbContext.WorkItems.Where(wi => wi.TicketId == id).ToListAsync();
    }

    public async Task<WorkItem> Update(WorkItem entity) {
      if (entity != null) {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
      }

      return entity;
    }
  }
}
