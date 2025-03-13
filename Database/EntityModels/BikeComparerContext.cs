using Microsoft.EntityFrameworkCore;

namespace Database.EntityModels;

public partial class BikeComparerContext : DbContext
{
    public BikeComparerContext()
    {
    }

    public BikeComparerContext(DbContextOptions<BikeComparerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BikeBrand> BikeBrands { get; set; }

    public virtual DbSet<BikeCategory> BikeCategories { get; set; }

    public virtual DbSet<BikeDataMain> BikeDataMains { get; set; }

    public virtual DbSet<BikeReview> BikeReviews { get; set; }

    public virtual DbSet<Chassie> Chassies { get; set; }

    public virtual DbSet<Circuit> Circuits { get; set; }

    public virtual DbSet<Cooling> Coolings { get; set; }

    public virtual DbSet<CylinderConfiguration> CylinderConfigurations { get; set; }

    public virtual DbSet<Engine> Engines { get; set; }

    public virtual DbSet<EngineType> EngineTypes { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<EquipmentBrand> EquipmentBrands { get; set; }

    public virtual DbSet<EquipmentModel> EquipmentModels { get; set; }

    public virtual DbSet<EquipmentReview> EquipmentReviews { get; set; }

    public virtual DbSet<EquipmentType> EquipmentTypes { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<NewsTag> NewsTags { get; set; }

    public virtual DbSet<NewsType> NewsTypes { get; set; }

    public virtual DbSet<Performance> Performances { get; set; }

    public virtual DbSet<PriceList> PriceLists { get; set; }

    public virtual DbSet<SimilarBike> SimilarBikes { get; set; }

    public virtual DbSet<Trackday> Trackdays { get; set; }

    public virtual DbSet<TrackdayOrganizer> TrackdayOrganizers { get; set; }

    public virtual DbSet<Transmission> Transmissions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-VNR0Q91\\SQLEXPRESS;Initial Catalog=2015095-hojdatabasen;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BikeBrand>(entity =>
        {
            entity.ToTable("BikeBrand");

            entity.Property(e => e.BikeBrandName).HasMaxLength(50);
            entity.Property(e => e.GeneralAgent).HasMaxLength(150);
            entity.Property(e => e.WebpageGlobal).HasMaxLength(100);
            entity.Property(e => e.WebpageSweden).HasMaxLength(100);
            entity.Property(e => e.SortId).HasColumnName("SortId");
        });

        modelBuilder.Entity<BikeCategory>(entity =>
        {
            entity.ToTable("BikeCategory");

            entity.Property(e => e.BikeCategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<BikeDataMain>(entity =>
        {
            entity.HasKey(e => e.McId).HasName("PK_General");

            entity.ToTable("BikeDataMain");

            entity.Property(e => e.Color).HasMaxLength(250);
            entity.Property(e => e.ImgUrl).HasMaxLength(50);
            entity.Property(e => e.ModelName).HasMaxLength(50);
            entity.Property(e => e.ModelNameCorrection).HasMaxLength(50);
            entity.Property(e => e.ModelNameUsa)
                .HasMaxLength(50)
                .HasColumnName("ModelNameUSA");
            entity.Property(e => e.PersonalComments).HasMaxLength(50);
            entity.Property(e => e.PriceUsa).HasColumnName("PriceUSA");
            entity.Property(e => e.PriceWithAbs).HasColumnName("PriceWithABS");
            entity.Property(e => e.ServiceInterval).HasMaxLength(150);
            entity.Property(e => e.ServiceIntervalEng).HasMaxLength(150);
            entity.Property(e => e.ServiceIntervalEngMiles).HasMaxLength(150);
            entity.Property(e => e.UpdatesForThisYear).HasMaxLength(1000);
            entity.Property(e => e.Warranty).HasMaxLength(150);

            entity.HasOne(d => d.BikeBrand).WithMany(p => p.BikeDataMains)
                .HasForeignKey(d => d.BikeBrandId)
                .HasConstraintName("FK_BikeDataMain_BikeBrand");

            entity.HasOne(d => d.BikeCategory).WithMany(p => p.BikeDataMains)
                .HasForeignKey(d => d.BikeCategoryId)
                .HasConstraintName("FK_BikeDataMain_BikeCategory");

            entity.HasOne(d => d.Chassie).WithMany(p => p.BikeDataMains)
                .HasForeignKey(d => d.ChassieId)
                .HasConstraintName("FK_General_Chassie");

            entity.HasOne(d => d.Engine).WithMany(p => p.BikeDataMains)
                .HasForeignKey(d => d.EngineId)
                .HasConstraintName("FK_General_Engine");

            entity.HasOne(d => d.Transmission).WithMany(p => p.BikeDataMains)
                .HasForeignKey(d => d.TransmissionId)
                .HasConstraintName("FK_General_Transmission");
        });

        modelBuilder.Entity<BikeReview>(entity =>
        {
            entity.Property(e => e.Header).HasMaxLength(50);
            entity.Property(e => e.Img).HasMaxLength(250);
            entity.Property(e => e.Negative).HasMaxLength(250);
            entity.Property(e => e.Positive).HasMaxLength(250);

            entity.HasOne(d => d.Mc).WithMany(p => p.BikeReviews)
                .HasForeignKey(d => d.McId)
                .HasConstraintName("FK_BikeReviews_General");
        });

        modelBuilder.Entity<Chassie>(entity =>
        {
            entity.ToTable("Chassie");

            entity.Property(e => e.AbsWeight).HasColumnName("ABS_Weight");
            entity.Property(e => e.AdjustableTc).HasColumnName("AdjustableTC");
            entity.Property(e => e.AdjustableTcDetailsText)
                .HasMaxLength(250)
                .HasColumnName("AdjustableTC_DetailsText");
            entity.Property(e => e.AdjustableTcDetailsTextEng)
                .HasMaxLength(250)
                .HasColumnName("AdjustableTC_DetailsTextEng");
            entity.Property(e => e.DisconnectableAbs).HasColumnName("Disconnectable_ABS");
            entity.Property(e => e.DryWeightKg).HasColumnName("DryWeight_Kg");
            entity.Property(e => e.DryWeightLb).HasColumnName("DryWeight_lb");
            entity.Property(e => e.DynamicDampingDetailsText).HasMaxLength(350);
            entity.Property(e => e.DynamicDampingDetailsTextEng).HasMaxLength(350);
            entity.Property(e => e.Frame).HasMaxLength(250);
            entity.Property(e => e.FrameEng).HasMaxLength(250);
            entity.Property(e => e.FrontBrakes).HasMaxLength(150);
            entity.Property(e => e.FrontBrakesEng).HasMaxLength(250);
            entity.Property(e => e.FrontSuspension).HasMaxLength(250);
            entity.Property(e => e.FrontSuspensionEng).HasMaxLength(250);
            entity.Property(e => e.FrontTyre).HasMaxLength(150);
            entity.Property(e => e.HasAbs).HasColumnName("Has_ABS");
            entity.Property(e => e.Rake).HasMaxLength(50);
            entity.Property(e => e.RearBrakes).HasMaxLength(150);
            entity.Property(e => e.RearBrakesEng).HasMaxLength(150);
            entity.Property(e => e.RearSuspension).HasMaxLength(250);
            entity.Property(e => e.RearSuspensionEng).HasMaxLength(250);
            entity.Property(e => e.RearTyre).HasMaxLength(150);
            entity.Property(e => e.SeatHeight).HasMaxLength(150);
            entity.Property(e => e.SeatHeightInches).HasMaxLength(150);
            entity.Property(e => e.Wheelbase).HasMaxLength(50);
            entity.Property(e => e.WheelbaseInches).HasMaxLength(50);
        });

        modelBuilder.Entity<Circuit>(entity =>
        {
            entity.HasKey(e => e.TrackId);

            entity.Property(e => e.TrackName).HasMaxLength(50);
        });

        modelBuilder.Entity<Cooling>(entity =>
        {
            entity.ToTable("Cooling");

            entity.Property(e => e.CoolingName).HasMaxLength(50);
            entity.Property(e => e.CoolingNameEng).HasMaxLength(50);
        });

        modelBuilder.Entity<CylinderConfiguration>(entity =>
        {
            entity.ToTable("CylinderConfiguration");

            entity.Property(e => e.CylinderConfigurationName).HasMaxLength(50);
            entity.Property(e => e.CylinderConfigurationNameEng).HasMaxLength(50);
        });

        modelBuilder.Entity<Engine>(entity =>
        {
            entity.ToTable("Engine");

            entity.HasIndex(e => e.MaxPower, "MaxPower");

            entity.Property(e => e.AdjustableEngineMapManagement).HasColumnName("Adjustable_EngineMapManagement");
            entity.Property(e => e.BoreXStroke)
                .HasMaxLength(50)
                .HasColumnName("Bore_X_Stroke");
            entity.Property(e => e.CompressionRatio).HasMaxLength(50);
            entity.Property(e => e.EngineMapDetailsText).HasMaxLength(250);
            entity.Property(e => e.EngineMapDetailsTextEng).HasMaxLength(250);
            entity.Property(e => e.FuelSystem).HasMaxLength(150);
            entity.Property(e => e.FuelSystemEng).HasMaxLength(150);
            entity.Property(e => e.IgnitionStarting)
                .HasMaxLength(50)
                .HasColumnName("Ignition/Starting");
            entity.Property(e => e.MaxTorqueFtlb).HasColumnName("Max_Torque_Ftlb");
            entity.Property(e => e.MaxTorqueKgm).HasColumnName("Max_Torque_Kgm");
            entity.Property(e => e.MaxTorqueKpm).HasColumnName("Max_Torque_Kpm");
            entity.Property(e => e.MaxTorqueNm).HasColumnName("Max_Torque_Nm");
            entity.Property(e => e.StartSystem).HasMaxLength(150);
            entity.Property(e => e.StartSystemEng).HasMaxLength(150);
            entity.Property(e => e.TransmissionDrive)
                .HasMaxLength(150)
                .HasColumnName("Transmission/Drive");

            entity.HasOne(d => d.Cooling).WithMany(p => p.Engines)
                .HasForeignKey(d => d.CoolingId)
                .HasConstraintName("FK_Engine_Cooling");

            entity.HasOne(d => d.CylinderConfiguration).WithMany(p => p.Engines)
                .HasForeignKey(d => d.CylinderConfigurationId)
                .HasConstraintName("FK_Engine_CylinderConfiguration");

            entity.HasOne(d => d.EngineType).WithMany(p => p.Engines)
                .HasForeignKey(d => d.EngineTypeId)
                .HasConstraintName("FK_Engine_EngineType");
        });

        modelBuilder.Entity<EngineType>(entity =>
        {
            entity.ToTable("EngineType");

            entity.Property(e => e.EngineTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasOne(d => d.EquipmentBrand).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.EquipmentBrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Equipment_EquipmentBrand");

            entity.HasOne(d => d.EquipmentModel).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.EquipmentModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Equipment_EquipmentModel");

            entity.HasOne(d => d.EquipmentType).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.EquipmentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Equipment_EquipmentType");
        });

        modelBuilder.Entity<EquipmentBrand>(entity =>
        {
            entity.ToTable("EquipmentBrand");

            entity.Property(e => e.EquipmentBrandName).HasMaxLength(50);
        });

        modelBuilder.Entity<EquipmentModel>(entity =>
        {
            entity.ToTable("EquipmentModel");

            entity.Property(e => e.EquipmentModelName).HasMaxLength(50);

            entity.HasOne(d => d.EquipmentBrand).WithMany(p => p.EquipmentModels)
                .HasForeignKey(d => d.EquipmentBrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EquipmentModel_EquipmentBrand");
        });

        modelBuilder.Entity<EquipmentReview>(entity =>
        {
            entity.HasKey(e => e.EquipmenReviewId);

            entity.Property(e => e.Header).HasMaxLength(250);
            entity.Property(e => e.ImgUrl).HasMaxLength(50);
            entity.Property(e => e.Negative).HasMaxLength(250);
            entity.Property(e => e.Positive).HasMaxLength(250);

            entity.HasOne(d => d.Equipment).WithMany(p => p.EquipmentReviews)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("FK_EquipmentReviews_Equipment");
        });

        modelBuilder.Entity<EquipmentType>(entity =>
        {
            entity.ToTable("EquipmentType");

            entity.Property(e => e.EquipmentTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.Property(e => e.Header).HasMaxLength(50);
            entity.Property(e => e.Img).HasMaxLength(50);
            entity.Property(e => e.ImgText).HasMaxLength(100);
            entity.Property(e => e.PublishDate).HasColumnType("datetime");
            entity.Property(e => e.TextDetail).HasMaxLength(500);
            entity.Property(e => e.TextTeaser).HasMaxLength(250);

            entity.HasOne(d => d.NewsType).WithMany(p => p.News)
                .HasForeignKey(d => d.NewsTypeId)
                .HasConstraintName("FK_News_News");
        });

        modelBuilder.Entity<NewsTag>(entity =>
        {
            entity.HasKey(e => e.TagId);

            entity.Property(e => e.TagName).HasMaxLength(50);
        });

        modelBuilder.Entity<NewsType>(entity =>
        {
            entity.ToTable("NewsType");

            entity.Property(e => e.NewsTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Performance>(entity =>
        {
            entity.ToTable("Performance");

            entity.Property(e => e.Acceleration0100kmH).HasColumnName("Acceleration0-100km/h");
            entity.Property(e => e.Acceleration0200kmH).HasColumnName("Acceleration0-200km/h");
            entity.Property(e => e.Acceleration060mph).HasColumnName("Acceleration0-60mph");
            entity.Property(e => e.Braking1000).HasColumnName("Braking100-0");
            entity.Property(e => e.Braking60mph0).HasColumnName("Braking60mph-0");
            entity.Property(e => e.Standing01000mTime).HasColumnName("Standing0-1000m_Time");
            entity.Property(e => e.Standing01000mTopSpeed).HasColumnName("Standing0-1000m_TopSpeed");
            entity.Property(e => e.Standing0400mTime).HasColumnName("Standing0-400m_Time");
            entity.Property(e => e.StandingMileTime).HasColumnName("StandingMile_Time");
            entity.Property(e => e.StandingQvarterMileTime).HasColumnName("StandingQvarterMile_Time");
            entity.Property(e => e.StandingQvarterMileTopSpeed).HasColumnName("StandingQvarterMile_TopSpeed");
        });

        modelBuilder.Entity<PriceList>(entity =>
        {
            entity.ToTable("PriceList");

            entity.HasOne(d => d.Mc).WithMany(p => p.PriceLists)
                .HasForeignKey(d => d.McId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PriceList_General");
        });

        modelBuilder.Entity<SimilarBike>(entity =>
        {
            entity.HasKey(e => e.McId).HasName("PK_SimilarBikes2");

            entity.Property(e => e.McId).ValueGeneratedNever();

            entity.HasOne(d => d.Mc).WithOne(p => p.SimilarBike)
                .HasForeignKey<SimilarBike>(d => d.McId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SimilarBikes2_BikeDataMain");
        });

        modelBuilder.Entity<Trackday>(entity =>
        {
            entity.Property(e => e.Groups).HasMaxLength(50);

            entity.HasOne(d => d.Organizer).WithMany(p => p.Trackdays)
                .HasForeignKey(d => d.OrganizerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trackdays_TrackdayOrganizers");

            entity.HasOne(d => d.Track).WithMany(p => p.Trackdays)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trackdays_Circuits");
        });

        modelBuilder.Entity<TrackdayOrganizer>(entity =>
        {
            entity.HasKey(e => e.OrganizerId);

            entity.Property(e => e.HomepageUrl).HasMaxLength(50);
            entity.Property(e => e.OrganizerName).HasMaxLength(50);
        });

        modelBuilder.Entity<Transmission>(entity =>
        {
            entity.ToTable("Transmission");

            entity.Property(e => e.Clutch).HasMaxLength(150);
            entity.Property(e => e.ClutchEng).HasMaxLength(150);
            entity.Property(e => e.FinalDrive).HasMaxLength(150);
            entity.Property(e => e.FinalDriveEng).HasMaxLength(150);
            entity.Property(e => e.Gearbox).HasMaxLength(150);
            entity.Property(e => e.GearboxEng).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
