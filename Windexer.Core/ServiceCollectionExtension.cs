﻿using WinDexer.Core.Managers;
using WinDexer.Model.Context;

namespace WinDexer.Core
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddWinDexerManagers(this IServiceCollection sc)
        {
            return sc             
                .AddDbContext<WinDexerContext>()                
                .AddSingleton<DbManager>()
                .AddSingleton<RootFoldersManager>()
                .AddSingleton<IndexEntriesManager>()
                .AddSingleton<IndexationManager>();            
        }
    }
}
