// <auto-generated />
using DataPanda.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataPanda.Persistence.Migrations
{
    [DbContext(typeof(DataPandaDbContext))]
    partial class DataPandaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataPanda.Domain.Entities.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("DataPanda.Domain.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FieldOfApplication")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("DataPanda.Domain.Entities.Enrolment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<double>("Grade")
                        .HasColumnType("float");

                    b.Property<int>("LearningPlatformId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("LearningPlatformId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrolments");
                });

            modelBuilder.Entity("DataPanda.Domain.Entities.EnrolmentAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<int>("EnrolmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("EnrolmentId");

                    b.ToTable("EnrolmentAssignments");
                });

            modelBuilder.Entity("DataPanda.Domain.Entities.EnrolmentWiki", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EnrolmentId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfEdits")
                        .HasColumnType("int");

                    b.Property<int>("WikiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnrolmentId");

                    b.HasIndex("WikiId");

                    b.ToTable("EnrolmentWikis");
                });

            modelBuilder.Entity("DataPanda.Domain.Entities.FileSubmission", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("EnrolmentAssignmentId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfFiles")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnrolmentAssignmentId");

                    b.ToTable("FileSubmissions");
                });

            modelBuilder.Entity("DataPanda.Domain.Entities.LearningPlatform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LearningPlatforms");
                });

            modelBuilder.Entity("DataPanda.Domain.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DataPanda.Domain.Entities.Wiki", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wikis");
                });

            modelBuilder.Entity("DataPanda.Domain.Entities.Enrolment", b =>
                {
                    b.HasOne("DataPanda.Domain.Entities.Course", "Course")
                        .WithMany("Enrolments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataPanda.Domain.Entities.LearningPlatform", "LearningPlatform")
                        .WithMany("Enrolments")
                        .HasForeignKey("LearningPlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataPanda.Domain.Entities.Student", "Student")
                        .WithMany("Enrolments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("LearningPlatform");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("DataPanda.Domain.Entities.EnrolmentAssignment", b =>
                {
                    b.HasOne("DataPanda.Domain.Entities.Assignment", "Assignment")
                        .WithMany("EnrolmentAssignments")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataPanda.Domain.Entities.Enrolment", "Enrolment")
                        .WithMany("EnrolmentAssignments")
                        .HasForeignKey("EnrolmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Enrolment");
                });

            modelBuilder.Entity("DataPanda.Domain.Entities.EnrolmentWiki", b =>
                {
                    b.HasOne("DataPanda.Domain.Entities.Enrolment", "Enrolment")
                        .WithMany("EnrolmentWikis")
                        .HasForeignKey("EnrolmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataPanda.Domain.Entities.Wiki", "Wiki")
                        .WithMany("EnrolmentWikis")
                        .HasForeignKey("WikiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enrolment");

                    b.Navigation("Wiki");
                });

            modelBuilder.Entity("DataPanda.Domain.Entities.FileSubmission", b =>
                {
                    b.HasOne("DataPanda.Domain.Entities.EnrolmentAssignment", "EnrolmentAssignments")
                        .WithMany("FileSubmissions")
                        .HasForeignKey("EnrolmentAssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EnrolmentAssignments");
                });

            modelBuilder.Entity("DataPanda.Domain.Entities.Assignment", b =>
                {
                    b.Navigation("EnrolmentAssignments");
                });

            modelBuilder.Entity("DataPanda.Domain.Entities.Course", b =>
                {
                    b.Navigation("Enrolments");
                });

            modelBuilder.Entity("DataPanda.Domain.Entities.Enrolment", b =>
                {
                    b.Navigation("EnrolmentAssignments");

                    b.Navigation("EnrolmentWikis");
                });

            modelBuilder.Entity("DataPanda.Domain.Entities.EnrolmentAssignment", b =>
                {
                    b.Navigation("FileSubmissions");
                });

            modelBuilder.Entity("DataPanda.Domain.Entities.LearningPlatform", b =>
                {
                    b.Navigation("Enrolments");
                });

            modelBuilder.Entity("DataPanda.Domain.Entities.Student", b =>
                {
                    b.Navigation("Enrolments");
                });

            modelBuilder.Entity("DataPanda.Domain.Entities.Wiki", b =>
                {
                    b.Navigation("EnrolmentWikis");
                });
#pragma warning restore 612, 618
        }
    }
}
