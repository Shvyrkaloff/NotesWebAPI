﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using NotesApplication.Common.Exception;
using NotesPresistence;
using NotesPresistence.Entities;

namespace NotesApplication.Notes.Commands.UpdateNote;

public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, Unit>
{
    private readonly  INotesDbContext _dbContext;
    public UpdateNoteCommandHandler(INotesDbContext dbContext) => _dbContext = dbContext;
    public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Notes.FirstOrDefaultAsync(note => note.Id == request.Id.ToString(), cancellationToken);
        if (entity == null)
        {
            throw new NotFoundException(nameof(Note), request.Id);
        }

        entity.Details = request.Details;
        entity.Title = request.Title;
        entity.EditDate = DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}