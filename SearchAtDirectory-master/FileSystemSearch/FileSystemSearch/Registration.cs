﻿using Autofac;
using FileSystemSearch.ConcreteProcessors;
using FileSystemSearch.FileWrapper;
using System;


namespace FileSystemSearch
{
    public static class Registration
    {
        public static IProcess processor;
        public static IFileWrapper fileWrapper;

        public static void Registrate<T>(ActionType type)
        {
            processor = GetBuilder<T>(type).Build().Resolve<IProcess>();
            fileWrapper = GetBuilder<T>(type).Build().Resolve<IFileWrapper>();
        }

        private static ContainerBuilder GetBuilder<T>(ActionType type)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<T>().As<IFileWrapper>();

            switch (type)
            {
                case ActionType.all:
                    builder.RegisterType<ProcessAll>().As<IProcess>();
                    break;
                case ActionType.spec:
                    builder.RegisterType<ProcessSPEC>().As<IProcess>();
                    break;//selector
                case ActionType.selector:
                    builder.RegisterType<ProcessSelector>().As<IProcess>();
                    break;
                default:
                    Console.WriteLine("Error type!");
                    break;
            }

            return builder;
        }
    }
}
