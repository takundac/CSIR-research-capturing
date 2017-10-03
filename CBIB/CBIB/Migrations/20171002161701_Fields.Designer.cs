using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CBIB.Models;

namespace CBIB.Migrations
{
    [DbContext(typeof(CBIBContext))]
    [Migration("20171002161701_Fields")]
    partial class Fields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CBIB.Models.Author", b =>
                {
                    b.Property<long>("AuthorID");

                    b.Property<string>("Name");

                    b.Property<long>("NodeID");

                    b.HasKey("AuthorID");

                    b.HasIndex("NodeID");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("CBIB.Models.Journal", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abstract")
                        .IsRequired();

                    b.Property<long>("AuthorID");

                    b.Property<string>("CoAuthor1");

                    b.Property<string>("CoAuthor2");

                    b.Property<string>("PeerReviewUrl");

                    b.Property<bool>("ProofOfPeereview");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("TypeOfResearchOutput")
                        .IsRequired();

                    b.Property<string>("Year")
                        .IsRequired();

                    b.Property<string>("url");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Journal");
                });

            modelBuilder.Entity("CBIB.Models.Node", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Node");
                });

            modelBuilder.Entity("CBIB.Models.Author", b =>
                {
                    b.HasOne("CBIB.Models.Node")
                        .WithMany("Authors")
                        .HasForeignKey("NodeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CBIB.Models.Journal", b =>
                {
                    b.HasOne("CBIB.Models.Author")
                        .WithMany("Journals")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
