﻿using WinDexer.Model.Entities;
using System.Linq.Dynamic.Core;

namespace WinDexer.Core.ViewModels;

public class FilteredListRequest
{
    public IQueryable<TEntity> ApplyOrderBy<TEntity>(IQueryable<TEntity> query) where TEntity : IEntity
    {
        if (!string.IsNullOrEmpty(OrderBy))
            return query.OrderBy(OrderBy);

        if (typeof(TEntity) == typeof(IndexEntry))
        {
            return query
                .Cast<IndexEntry>()
                .OrderBy(e_ => e_.Root.Path)
                .ThenBy(e_ => e_.RelativePath)
                .Cast<TEntity>();
        }

        if (typeof(TEntity) == typeof(RootFolder))
        {
            return query
                .Cast<RootFolder>()
                .OrderBy(e_ => e_.Path)
                .Cast<TEntity>();
        }

        throw new NotImplementedException();
    }   

    public string? Filter { get; set; }
    public string? OrderBy { get; set; }
    public int Skip { get; set; }
    public int Top { get; set; }
}

public class FilteredListResponse<TEntity> where TEntity : IEntity
{
    public List<TEntity> Data { get; set; } = new();
    public int TotalCount { get; set; }
}
