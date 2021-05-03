﻿using Autofac;
using DataPanda.Startup.IoC.Persistence.Entities.Courses;
using DataPanda.Startup.IoC.Persistence.Entities.Enrolments;
using DataPanda.Startup.IoC.Persistence.Entities.LearningPlatforms;
using DataPanda.Startup.IoC.Persistence.Entities.Students;

namespace DataPanda.Startup.IoC.Persistence.Entities
{
    public static class EntitiesCqrsContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterCourseCqrs(builder);
            RegisterEnrolmentCqrs(builder);
            RegisterLearningPlatformCqrs(builder);
            RegisterStudentCqrs(builder);
        }

        private static void RegisterCourseCqrs(ContainerBuilder builder)
        {
            CourseCommandsContainer.Register(builder);
            CourseQueriesContainer.Register(builder);
        }

        private static void RegisterEnrolmentCqrs(ContainerBuilder builder)
        {
            EnrolmentCommandsContainer.Register(builder);
            EnrolmentQueriresContainer.Register(builder);
        }

        private static void RegisterLearningPlatformCqrs(ContainerBuilder builder)
        {
            LearningPlatformCommandsContainer.Register(builder);
            LearningPlatformQueriesContainer.Register(builder);
        }

        private static void RegisterStudentCqrs(ContainerBuilder builder)
        {
            StudentCommandsContainer.Register(builder);
            StudentsQueriesContainer.Register(builder);
        }
    }
}
