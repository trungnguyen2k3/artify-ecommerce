using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Artify_ecommerce.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<AgentFolder> AgentFolders { get; set; }

    public virtual DbSet<AgentFolderPermission> AgentFolderPermissions { get; set; }

    public virtual DbSet<AgentPage> AgentPages { get; set; }

    public virtual DbSet<B2bCustomer> B2bCustomers { get; set; }

    public virtual DbSet<B2bCustomerContact> B2bCustomerContacts { get; set; }

    public virtual DbSet<B2bCustomerNote> B2bCustomerNotes { get; set; }

    public virtual DbSet<B2bMasterDatum> B2bMasterData { get; set; }

    public virtual DbSet<BlogCategory> BlogCategories { get; set; }

    public virtual DbSet<BlogComment> BlogComments { get; set; }

    public virtual DbSet<BlogProduct> BlogProducts { get; set; }

    public virtual DbSet<BlogProductApprovalConfig> BlogProductApprovalConfigs { get; set; }

    public virtual DbSet<BlogProductCoreStock> BlogProductCoreStocks { get; set; }

    public virtual DbSet<BlogProductEditRequest> BlogProductEditRequests { get; set; }

    public virtual DbSet<BlogProductTag> BlogProductTags { get; set; }

    public virtual DbSet<BlogProductVariant> BlogProductVariants { get; set; }

    public virtual DbSet<BlogReview> BlogReviews { get; set; }

    public virtual DbSet<BlogproductVariantPriceMaster> BlogproductVariantPriceMasters { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Channel> Channels { get; set; }

    public virtual DbSet<CollectionProduct> CollectionProducts { get; set; }

    public virtual DbSet<CollectionTag> CollectionTags { get; set; }

    public virtual DbSet<Config> Configs { get; set; }

    public virtual DbSet<CrawlArticle> CrawlArticles { get; set; }

    public virtual DbSet<CrawlLog> CrawlLogs { get; set; }

    public virtual DbSet<CrawlWebsite> CrawlWebsites { get; set; }

    public virtual DbSet<CsmConsignment> CsmConsignments { get; set; }

    public virtual DbSet<CsmConsignmentImage> CsmConsignmentImages { get; set; }

    public virtual DbSet<CsmConsignmentLog> CsmConsignmentLogs { get; set; }

    public virtual DbSet<CsmContract> CsmContracts { get; set; }

    public virtual DbSet<CsmContractAnnex> CsmContractAnnexes { get; set; }

    public virtual DbSet<CsmContractAnnexProduct> CsmContractAnnexProducts { get; set; }

    public virtual DbSet<CsmContractClause> CsmContractClauses { get; set; }

    public virtual DbSet<CsmContractTemplate> CsmContractTemplates { get; set; }

    public virtual DbSet<CsmContractTemplateClause> CsmContractTemplateClauses { get; set; }

    public virtual DbSet<CsmHandover> CsmHandovers { get; set; }

    public virtual DbSet<CsmHandoverDetail> CsmHandoverDetails { get; set; }

    public virtual DbSet<CsmMasterDatum> CsmMasterData { get; set; }

    public virtual DbSet<CsmPartner> CsmPartners { get; set; }

    public virtual DbSet<CsmPartnerContact> CsmPartnerContacts { get; set; }

    public virtual DbSet<CsmPartnerLevelPolicy> CsmPartnerLevelPolicies { get; set; }

    public virtual DbSet<CsmPartnerNote> CsmPartnerNotes { get; set; }

    public virtual DbSet<CsmStaff> CsmStaffs { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DailyStat> DailyStats { get; set; }

    public virtual DbSet<EmployeeTemp> EmployeeTemps { get; set; }

    public virtual DbSet<ErpPermission> ErpPermissions { get; set; }

    public virtual DbSet<ErpUser> ErpUsers { get; set; }

    public virtual DbSet<ErpUserPermission> ErpUserPermissions { get; set; }

    public virtual DbSet<FinishType> FinishTypes { get; set; }

    public virtual DbSet<HorizontalPainting> HorizontalPaintings { get; set; }

    public virtual DbSet<HorizontalPaintingImage> HorizontalPaintingImages { get; set; }

    public virtual DbSet<HorizontalPaintingTag> HorizontalPaintingTags { get; set; }

    public virtual DbSet<InventoryHistory> InventoryHistories { get; set; }

    public virtual DbSet<LoginHistory> LoginHistories { get; set; }

    public virtual DbSet<MasterExcelCellMapping> MasterExcelCellMappings { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MdfBoard> MdfBoards { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderHistory> OrderHistories { get; set; }

    public virtual DbSet<OrderSequence> OrderSequences { get; set; }

    public virtual DbSet<PageView> PageViews { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostCategory> PostCategories { get; set; }

    public virtual DbSet<PostVersion> PostVersions { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<ShopCategory> ShopCategories { get; set; }

    public virtual DbSet<ShopProduct> ShopProducts { get; set; }

    public virtual DbSet<ShopProductImage> ShopProductImages { get; set; }

    public virtual DbSet<SiteContent> SiteContents { get; set; }

    public virtual DbSet<StaticContent> StaticContents { get; set; }

    public virtual DbSet<StaticPage> StaticPages { get; set; }

    public virtual DbSet<SystemWidthBlogProduct> SystemWidthBlogProducts { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TextEditorMediaItem> TextEditorMediaItems { get; set; }

    public virtual DbSet<VisitorSession> VisitorSessions { get; set; }

    public virtual DbSet<Wishlist> Wishlists { get; set; }

    public virtual DbSet<WishlistItem> WishlistItems { get; set; }

    public virtual DbSet<ZaloNotification> ZaloNotifications { get; set; }

    public virtual DbSet<ZaloToken> ZaloTokens { get; set; }

    public virtual DbSet<ZaloUser> ZaloUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS,1433;Database=artify;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC07BEDE6474");

            entity.ToTable("Account");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.GoogleId).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true, "DF_Account_IsActive");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.RefreshToken).HasMaxLength(500);
            entity.Property(e => e.RoleId).HasDefaultValue(2, "DF_Account_RoleId");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Agent__3214EC07EC2EB011");

            entity.ToTable("Agent");

            entity.HasIndex(e => e.Username, "UQ__Agent__536C85E4CBFCC839").IsUnique();

            entity.HasIndex(e => e.Code, "UQ__Agent__A25C5AA7D6CF4312").IsUnique();

            entity.Property(e => e.AgentDiscount).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.BankAccountNumber).HasMaxLength(50);
            entity.Property(e => e.BankName).HasMaxLength(100);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Discount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ExpiredDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VerifyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AgentFolder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AgentFol__3214EC078BDA46C0");

            entity.ToTable("AgentFolder");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FolderName).HasMaxLength(255);
        });

        modelBuilder.Entity<AgentFolderPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AgentFol__3214EC07662B9543");

            entity.ToTable("AgentFolderPermission");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<AgentPage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AgentPag__3214EC07D36C5074");

            entity.ToTable("AgentPage");

            entity.HasIndex(e => e.Slug, "UQ__AgentPag__BC7B5FB6134531B5").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Slug).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<B2bCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__B2b_Cust__3214EC07F38BEA89");

            entity.ToTable("B2b_Customer");

            entity.HasIndex(e => e.CustomerCode, "UQ_B2bCustomer_Code").IsUnique();

            entity.Property(e => e.AssignedStaff).HasMaxLength(100);
            entity.Property(e => e.AuthorizationFileUrl).HasMaxLength(500);
            entity.Property(e => e.AuthorizedPerson).HasMaxLength(100);
            entity.Property(e => e.BankAccount).HasMaxLength(200);
            entity.Property(e => e.BusinessLicenseUrl).HasMaxLength(500);
            entity.Property(e => e.CompanyName).HasMaxLength(200);
            entity.Property(e => e.ContactPerson).HasMaxLength(100);
            entity.Property(e => e.ContactPosition).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CustomerCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CustomerType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DistrictCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DistrictName).HasMaxLength(100);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Industry).HasMaxLength(100);
            entity.Property(e => e.InvoiceAddress).HasMaxLength(500);
            entity.Property(e => e.InvoiceEmail).HasMaxLength(100);
            entity.Property(e => e.InvoiceName).HasMaxLength(200);
            entity.Property(e => e.LegalAddress).HasMaxLength(500);
            entity.Property(e => e.LegalNotes).HasMaxLength(1000);
            entity.Property(e => e.LegalRepresentative).HasMaxLength(100);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProvinceCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ProvinceName).HasMaxLength(100);
            entity.Property(e => e.ShippingAddress).HasMaxLength(500);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("active");
            entity.Property(e => e.TaxCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.Website)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<B2bCustomerContact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__B2b_Cust__3214EC077E6D5B1C");

            entity.ToTable("B2b_CustomerContact");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsPrimary).HasDefaultValue(false);
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Position).HasMaxLength(100);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<B2bCustomerNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__B2b_Cust__3214EC07B45FCE54");

            entity.ToTable("B2b_CustomerNote");

            entity.Property(e => e.AttachmentUrl).HasMaxLength(500);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FollowUpStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("pending");
            entity.Property(e => e.NextAction).HasMaxLength(500);
            entity.Property(e => e.Result).HasMaxLength(500);
            entity.Property(e => e.StaffName).HasMaxLength(100);
        });

        modelBuilder.Entity<B2bMasterDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__B2b_Mast__3214EC079C853D6D");

            entity.ToTable("B2b_MasterData");

            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NameVi).HasMaxLength(100);
            entity.Property(e => e.SortOrder).HasDefaultValue(0);
        });

        modelBuilder.Entity<BlogCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BlogCate__3214EC073C96AA2C");

            entity.ToTable("BlogCategory");

            entity.Property(e => e.CategoryName).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MetaDescription).HasMaxLength(500);
            entity.Property(e => e.MetaKeywords).HasMaxLength(500);
            entity.Property(e => e.MetaTitle).HasMaxLength(200);
            entity.Property(e => e.Slug).HasMaxLength(300);
        });

        modelBuilder.Entity<BlogComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BlogComm__3214EC07EDF6A0AD");

            entity.ToTable("BlogComment");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<BlogProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BlogProd__3214EC074869E9F7");

            entity.ToTable("BlogProduct");

            entity.HasIndex(e => e.TempId, "UQ_BlogProduct_TempId")
                .IsUnique()
                .HasFilter("([TempId] IS NOT NULL)");

            entity.Property(e => e.AuthorName).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MetaDescription).HasMaxLength(500);
            entity.Property(e => e.MetaKeywords).HasMaxLength(500);
            entity.Property(e => e.MetaTitle).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Photo).HasMaxLength(500);
            entity.Property(e => e.Sku)
                .HasMaxLength(250)
                .HasColumnName("SKU");
            entity.Property(e => e.Slug).HasMaxLength(300);
            entity.Property(e => e.TempId).HasMaxLength(50);
        });

        modelBuilder.Entity<BlogProductApprovalConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BlogProd__3214EC0772632BCD");

            entity.ToTable("BlogProductApprovalConfig");

            entity.HasIndex(e => e.ApproverAdminId, "UQ_BPAC_Approver").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<BlogProductCoreStock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BlogProd__3214EC07833A4C6D");

            entity.ToTable("BlogProductCoreStock");

            entity.HasIndex(e => new { e.BlogProductId, e.MaterialId }, "UQ_BlogProductCoreStock").IsUnique();
        });

        modelBuilder.Entity<BlogProductEditRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BlogProd__3214EC0746B8832C");

            entity.ToTable("BlogProductEditRequest");

            entity.HasIndex(e => e.BlogProductId, "IX_BPER_BlogProductId");

            entity.HasIndex(e => e.CreatedAt, "IX_BPER_CreatedAt").IsDescending();

            entity.HasIndex(e => e.Status, "IX_BPER_Status");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RejectReason).HasMaxLength(500);
            entity.Property(e => e.ResolvedAt).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pending");
        });

        modelBuilder.Entity<BlogProductTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BlogProd__3214EC07A830139E");

            entity.ToTable("BlogProductTag");
        });

        modelBuilder.Entity<BlogProductVariant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BlogProd__3214EC07CF93224B");

            entity.ToTable("BlogProductVariant");

            entity.Property(e => e.FinishType).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Material).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<BlogReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BlogRevi__3214EC07BE8A6249");

            entity.ToTable("BlogReview");

            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<BlogproductVariantPriceMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Blogprod__3214EC07FF8A2189");

            entity.ToTable("BlogproductVariantPriceMaster");

            entity.Property(e => e.FinishType).HasMaxLength(100);
            entity.Property(e => e.Material).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cart__3214EC074F56D47A");

            entity.ToTable("Cart");

            entity.Property(e => e.FinishType).HasMaxLength(100);
            entity.Property(e => e.FrameColor).HasMaxLength(100);
            entity.Property(e => e.Material).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.ProductType).HasMaxLength(50);
            entity.Property(e => e.ShopCode).HasMaxLength(50);
            entity.Property(e => e.Sku).HasMaxLength(100);
        });

        modelBuilder.Entity<Channel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Channel__3214EC07EDD7FB64");

            entity.ToTable("Channel");

            entity.HasIndex(e => e.Code, "UQ__Channel__A25C5AA791478045").IsUnique();

            entity.Property(e => e.Channel1)
                .HasMaxLength(100)
                .HasColumnName("Channel");
            entity.Property(e => e.Code).HasMaxLength(10);
        });

        modelBuilder.Entity<CollectionProduct>(entity =>
        {
            entity.HasKey(e => new { e.CollectionId, e.ProductId }).HasName("PK__Collecti__B6A670680D1B9F38");

            entity.ToTable("CollectionProduct");
        });

        modelBuilder.Entity<CollectionTag>(entity =>
        {
            entity.HasKey(e => new { e.CollectionId, e.TagId }).HasName("PK__Collecti__ABB1739EECF3A8A4");

            entity.ToTable("CollectionTag");
        });

        modelBuilder.Entity<Config>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Config__3214EC071758D08F");

            entity.ToTable("Config");

            entity.Property(e => e.Config1)
                .HasMaxLength(255)
                .HasColumnName("Config");
        });

        modelBuilder.Entity<CrawlArticle>(entity =>
        {
            entity.HasKey(e => e.ArticleId);

            entity.ToTable("CrawlArticle");

            entity.Property(e => e.ArticleId).HasColumnName("ArticleID");
            entity.Property(e => e.CrawlError).HasMaxLength(1000);
            entity.Property(e => e.CrawlStatus).HasDefaultValue((byte)0, "DF_CrawlArticle_CrawlStatus");
            entity.Property(e => e.CrawledDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())", "DF_CrawlArticle_CreatedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.EditStatus).HasDefaultValue((byte)0, "DF_CrawlArticle_EditStatus");
            entity.Property(e => e.EditedBy).HasMaxLength(100);
            entity.Property(e => e.EditedDate).HasColumnType("datetime");
            entity.Property(e => e.MetaDescription).HasMaxLength(1000);
            entity.Property(e => e.MetaKeywords).HasMaxLength(1000);
            entity.Property(e => e.Notes).HasMaxLength(2000);
            entity.Property(e => e.OgImage).HasMaxLength(1000);
            entity.Property(e => e.PublishedDate).HasColumnType("datetime");
            entity.Property(e => e.PublishedToWebDate).HasColumnType("datetime");
            entity.Property(e => e.Slug).HasMaxLength(500);
            entity.Property(e => e.Tags).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Url).HasMaxLength(1000);
            entity.Property(e => e.WebsiteId).HasColumnName("WebsiteID");

            entity.HasOne(d => d.Website).WithMany(p => p.CrawlArticles)
                .HasForeignKey(d => d.WebsiteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CrawlArticle_Website");
        });

        modelBuilder.Entity<CrawlLog>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.ToTable("CrawlLog");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.ErrorMessage).HasMaxLength(1000);
            entity.Property(e => e.StartTime)
                .HasDefaultValueSql("(getdate())", "DF_CrawlLog_StartTime")
                .HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.WebsiteId).HasColumnName("WebsiteID");

            entity.HasOne(d => d.Website).WithMany(p => p.CrawlLogs)
                .HasForeignKey(d => d.WebsiteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CrawlLog_Website");
        });

        modelBuilder.Entity<CrawlWebsite>(entity =>
        {
            entity.HasKey(e => e.WebsiteId);

            entity.ToTable("CrawlWebsite");

            entity.Property(e => e.WebsiteId).HasColumnName("WebsiteID");
            entity.Property(e => e.BaseUrl).HasMaxLength(500);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())", "DF_CrawlWebsite_CreatedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.IsActive).HasDefaultValue(true, "DF_CrawlWebsite_IsActive");
            entity.Property(e => e.SitemapUrl).HasMaxLength(500);
            entity.Property(e => e.WebsiteName).HasMaxLength(200);
        });

        modelBuilder.Entity<CsmConsignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Csm_Cons__3214EC07B159D8DB");

            entity.ToTable("Csm_Consignment");

            entity.HasIndex(e => e.BatchCode, "IX_Consignment_Batch");

            entity.HasIndex(e => e.ContractId, "IX_Consignment_Contract");

            entity.HasIndex(e => e.HandoverId, "IX_Consignment_Handover");

            entity.HasIndex(e => e.PartnerId, "IX_Consignment_Partner");

            entity.HasIndex(e => e.Sku, "IX_Consignment_SKU");

            entity.HasIndex(e => e.SentDate, "IX_Consignment_SentDate");

            entity.HasIndex(e => e.Status, "IX_Consignment_Status");

            entity.HasIndex(e => e.ConsignmentCode, "UQ_Consignment_Code").IsUnique();

            entity.Property(e => e.BatchCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BatchStatus)
                .HasMaxLength(20)
                .HasDefaultValue("open");
            entity.Property(e => e.CommissionRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ConsignmentCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.DisplayLocation).HasMaxLength(200);
            entity.Property(e => e.MinimumPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(200);
            entity.Property(e => e.ProductType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.QuantityAvailable).HasComputedColumnSql("((((([QuantitySent]-[QuantitySold])-[QuantityReturned])-[QuantityDamaged])-[QuantityLost])-[QuantityRecalled])", false);
            entity.Property(e => e.RetailPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SKU");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("consigned");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .HasDefaultValue("Cái");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            entity.Property(e => e.VariantInfo).HasMaxLength(500);
        });

        modelBuilder.Entity<CsmConsignmentImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Csm_Cons__3214EC076E3BD779");

            entity.ToTable("Csm_ConsignmentImage");

            entity.HasIndex(e => e.ConsignmentId, "IX_ConsignmentImage_Consignment");

            entity.HasIndex(e => e.ImageType, "IX_ConsignmentImage_Type");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.ImageType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl).HasMaxLength(500);
            entity.Property(e => e.Note).HasMaxLength(500);
        });

        modelBuilder.Entity<CsmConsignmentLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Csm_Cons__3214EC077932F6F3");

            entity.ToTable("Csm_ConsignmentLog");

            entity.HasIndex(e => e.Action, "IX_ConsignmentLog_Action");

            entity.HasIndex(e => e.ConsignmentId, "IX_ConsignmentLog_Consignment");

            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.NewValue).HasMaxLength(500);
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.OldValue).HasMaxLength(500);
        });

        modelBuilder.Entity<CsmContract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Csm_Cont__3214EC079CF0D78E");

            entity.ToTable("Csm_Contract");

            entity.Property(e => e.ContractCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContractType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.FileUrl).HasMaxLength(500);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("draft");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<CsmContractAnnex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Csm_Cont__3214EC073BD209F0");

            entity.ToTable("Csm_ContractAnnex");

            entity.Property(e => e.AnnexCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.FileUrl).HasMaxLength(500);
        });

        modelBuilder.Entity<CsmContractAnnexProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Csm_Cont__3214EC07E775B45E");

            entity.ToTable("Csm_ContractAnnexProduct");

            entity.Property(e => e.Note).HasMaxLength(250);
            entity.Property(e => e.ProductType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SKU");
        });

        modelBuilder.Entity<CsmContractClause>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Csm_Cont__3214EC079EB67C3C");

            entity.ToTable("Csm_ContractClause");

            entity.Property(e => e.ClauseOrder).HasDefaultValue(1);
            entity.Property(e => e.ClauseTitle).HasMaxLength(200);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<CsmContractTemplate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Csm_Cont__3214EC074829CFB8");

            entity.ToTable("Csm_ContractTemplate");

            entity.Property(e => e.ContractType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDefault).HasDefaultValue(true);
            entity.Property(e => e.TemplateName).HasMaxLength(200);
        });

        modelBuilder.Entity<CsmContractTemplateClause>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Csm_Cont__3214EC071244B940");

            entity.ToTable("Csm_ContractTemplateClause");

            entity.Property(e => e.ClauseOrder).HasDefaultValue(1);
            entity.Property(e => e.ClauseTitle).HasMaxLength(200);
        });

        modelBuilder.Entity<CsmHandover>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Csm_Hand__3214EC07583FE7CF");

            entity.ToTable("Csm_Handover");

            entity.Property(e => e.Condition).HasMaxLength(200);
            entity.Property(e => e.ConfirmedAt).HasColumnType("datetime");
            entity.Property(e => e.ConfirmedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.DeliveryLocation).HasMaxLength(500);
            entity.Property(e => e.FileUrl).HasMaxLength(500);
            entity.Property(e => e.HandoverCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReceiverName).HasMaxLength(100);
            entity.Property(e => e.ReconcileStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReconciledAt).HasColumnType("datetime");
            entity.Property(e => e.ReconciledBy).HasMaxLength(100);
            entity.Property(e => e.SenderName).HasMaxLength(100);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("draft");
        });

        modelBuilder.Entity<CsmHandoverDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Csm_Hand__3214EC079F89FC54");

            entity.ToTable("Csm_HandoverDetail");

            entity.Property(e => e.DiscountAmount)
                .HasDefaultValue(0m, "DF_Csm_HandoverDetail_DiscountAmount")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DiscountRate)
                .HasDefaultValue(0m, "DF_Csm_HandoverDetail_DiscountRate")
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.FinalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(200);
            entity.Property(e => e.ProductType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RetailPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SKU");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .HasDefaultValue("Cái", "DF_Csm_HandoverDetail_Unit");
            entity.Property(e => e.VariantInfo).HasMaxLength(500);
        });

        modelBuilder.Entity<CsmMasterDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Csm_Mast__3214EC073D362A6A");

            entity.ToTable("Csm_MasterData");

            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NameVi).HasMaxLength(100);
            entity.Property(e => e.SortOrder).HasDefaultValue(0);
        });

        modelBuilder.Entity<CsmPartner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Csm_Part__3214EC071FD195C3");

            entity.ToTable("Csm_Partner");

            entity.HasIndex(e => e.PartnerCode, "UQ_Partner_Code").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.AssignedStaff).HasMaxLength(100);
            entity.Property(e => e.BankAccount).HasMaxLength(30);
            entity.Property(e => e.BankBranch).HasMaxLength(100);
            entity.Property(e => e.BankName).HasMaxLength(100);
            entity.Property(e => e.BusinessLicenseUrl).HasMaxLength(500);
            entity.Property(e => e.CompanyName).HasMaxLength(255);
            entity.Property(e => e.ConsignmentDuration).HasDefaultValue(90);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.DebtLimit)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DefaultCommissionRate)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.InvoiceAddress).HasMaxLength(500);
            entity.Property(e => e.InvoiceEmail).HasMaxLength(100);
            entity.Property(e => e.InvoiceName).HasMaxLength(200);
            entity.Property(e => e.LegalType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PartnerCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PartnerLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("normal");
            entity.Property(e => e.PartnerName).HasMaxLength(200);
            entity.Property(e => e.PartnerType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PaymentTerm).HasMaxLength(500);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ProvinceCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ProvinceName).HasMaxLength(100);
            entity.Property(e => e.ReconciliationCycle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("monthly");
            entity.Property(e => e.Representative).HasMaxLength(100);
            entity.Property(e => e.RiskLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("low");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("active");
            entity.Property(e => e.SupportStaff).HasMaxLength(100);
            entity.Property(e => e.TaxCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.WardCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.WardName).HasMaxLength(100);
        });

        modelBuilder.Entity<CsmPartnerContact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Csm_Part__3214EC07ADAE2731");

            entity.ToTable("Csm_PartnerContact");

            entity.Property(e => e.ContactName).HasMaxLength(100);
            entity.Property(e => e.ContactRole)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsPrimary).HasDefaultValue(false);
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CsmPartnerLevelPolicy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Csm_Part__3214EC072C352101");

            entity.ToTable("Csm_PartnerLevelPolicy");

            entity.HasIndex(e => e.LevelCode, "UQ_LevelPolicy_Code").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DefaultCommissionRate)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DefaultConsignmentDuration).HasDefaultValue(90);
            entity.Property(e => e.DefaultDebtLimit)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DefaultPaymentTerm).HasMaxLength(500);
            entity.Property(e => e.DefaultReconciliationCycle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("monthly");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LevelCode).HasMaxLength(50);
            entity.Property(e => e.LevelName).HasMaxLength(100);
            entity.Property(e => e.SortOrder).HasDefaultValue(0);
        });

        modelBuilder.Entity<CsmPartnerNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Csm_Part__3214EC07E7CF500E");

            entity.ToTable("Csm_PartnerNote");

            entity.Property(e => e.AttachmentUrl).HasMaxLength(500);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FollowUpStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("pending");
            entity.Property(e => e.NextAction).HasMaxLength(500);
            entity.Property(e => e.Result).HasMaxLength(500);
            entity.Property(e => e.StaffName).HasMaxLength(100);
        });

        modelBuilder.Entity<CsmStaff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Csm_Staf__3214EC074BF259E0");

            entity.ToTable("Csm_Staff");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DepartmentCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.StaffName).HasMaxLength(100);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07BEE2B6EB");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Customer__85FB4E38795E6334").IsUnique();

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
        });

        modelBuilder.Entity<DailyStat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DailySta__3214EC07DA4C3966");

            entity.HasIndex(e => e.Date, "IX_DailyStats_Date");

            entity.HasIndex(e => e.Date, "UQ__DailySta__77387D079E6FFA8C").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TopPage).HasMaxLength(500);
            entity.Property(e => e.TopUtmSource).HasMaxLength(200);
        });

        modelBuilder.Entity<EmployeeTemp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC0760713F8C");

            entity.ToTable("EmployeeTemp");
        });

        modelBuilder.Entity<ErpPermission>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("Erp_Permission");

            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.Module).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<ErpUser>(entity =>
        {
            entity.ToTable("Erp_User");

            entity.HasIndex(e => e.Username, "UQ_Erp_User_Username").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<ErpUserPermission>(entity =>
        {
            entity.ToTable("Erp_UserPermission");

            entity.Property(e => e.PermissionCode).HasMaxLength(100);
        });

        modelBuilder.Entity<FinishType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FinishTy__3214EC07C014DE5B");

            entity.ToTable("FinishType");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Material).WithMany(p => p.FinishTypes)
                .HasForeignKey(d => d.MaterialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FinishTyp__Mater__3E1D39E1");
        });

        modelBuilder.Entity<HorizontalPainting>(entity =>
        {
            entity.ToTable("HorizontalPainting");

            entity.HasIndex(e => e.Slug, "IX_HorizontalPainting_Slug");

            entity.HasIndex(e => e.Sku, "UQ_HorizontalPainting_SKU").IsUnique();

            entity.HasIndex(e => e.TempId, "UQ_HorizontalPainting_TempId")
                .IsUnique()
                .HasFilter("([TempId] IS NOT NULL)");

            entity.Property(e => e.AuthorName).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MetaDescription).HasMaxLength(500);
            entity.Property(e => e.MetaKeywords).HasMaxLength(500);
            entity.Property(e => e.MetaTitle).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Photo).HasMaxLength(500);
            entity.Property(e => e.Sku)
                .HasMaxLength(250)
                .HasColumnName("SKU");
            entity.Property(e => e.Slug).HasMaxLength(300);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<HorizontalPaintingImage>(entity =>
        {
            entity.ToTable("HorizontalPaintingImage");

            entity.Property(e => e.ImagePath).HasMaxLength(500);
            entity.Property(e => e.ImageType).HasMaxLength(50);
        });

        modelBuilder.Entity<HorizontalPaintingTag>(entity =>
        {
            entity.ToTable("HorizontalPaintingTag");

            entity.HasIndex(e => new { e.HorizontalPaintingId, e.TagId }, "UQ_HPTag_PaintingTag").IsUnique();
        });

        modelBuilder.Entity<InventoryHistory>(entity =>
        {
            entity.ToTable("InventoryHistory");

            entity.Property(e => e.ChangeType).HasMaxLength(20);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.ShopCode).HasMaxLength(20);
        });

        modelBuilder.Entity<LoginHistory>(entity =>
        {
            entity.ToTable("LoginHistory");

            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.IpAddress).HasMaxLength(50);
            entity.Property(e => e.Region).HasMaxLength(100);
            entity.Property(e => e.Time)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserAgent).HasMaxLength(500);

            entity.HasOne(d => d.Account).WithMany(p => p.LoginHistories)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_LoginHistory_Account");
        });

        modelBuilder.Entity<MasterExcelCellMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MasterEx__3214EC077CCE89FD");

            entity.ToTable("MasterExcelCellMapping");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.PriceCellAddress)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.VariantKey).HasMaxLength(100);
            entity.Property(e => e.WidthCellAddress)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Material__3214EC0777DB25CA");

            entity.ToTable("Material");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<MdfBoard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MdfBoard__3214EC07E3F36CE8");

            entity.ToTable("MdfBoard");

            entity.HasIndex(e => new { e.Width, e.Type }, "UQ_MdfBoard_Width_Type").IsUnique();

            entity.Property(e => e.Width).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC078B1ACCCD");

            entity.ToTable("Order");

            entity.Property(e => e.ConvertedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DiscountPercent).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.District).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(150);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.OrderNumber).HasMaxLength(50);
            entity.Property(e => e.OrderType).HasMaxLength(20);
            entity.Property(e => e.OriginalOrderNumber).HasMaxLength(50);
            entity.Property(e => e.PaymentProvider).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.Province).HasMaxLength(100);
            entity.Property(e => e.ShippingFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransactionCode).HasMaxLength(255);
            entity.Property(e => e.UtmSource).HasMaxLength(100);
            entity.Property(e => e.Ward).HasMaxLength(100);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC07F7DB6313");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.FinishType).HasMaxLength(100);
            entity.Property(e => e.FrameColor).HasMaxLength(100);
            entity.Property(e => e.Material).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.ProductType)
                .HasMaxLength(20)
                .HasDefaultValue("PAINTING");
            entity.Property(e => e.ShopCode).HasMaxLength(20);
        });

        modelBuilder.Entity<OrderHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderHis__3214EC07E817A0FF");

            entity.ToTable("OrderHistory");

            entity.HasIndex(e => e.ActionDate, "IX_OrderHistory_ActionDate").IsDescending();

            entity.HasIndex(e => e.OrderId, "IX_OrderHistory_OrderId");

            entity.Property(e => e.ActionBy).HasMaxLength(100);
            entity.Property(e => e.ActionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ActionType).HasMaxLength(50);
            entity.Property(e => e.ChangeSummary).HasMaxLength(500);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderHistories)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderHistory_Order");
        });

        modelBuilder.Entity<OrderSequence>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderSeq__3214EC07A1B66775");

            entity.ToTable("OrderSequence");

            entity.HasIndex(e => new { e.SequenceDate, e.Channel }, "UQ_OrderSequence_DateChannel").IsUnique();

            entity.Property(e => e.Channel)
                .HasMaxLength(10)
                .HasDefaultValue("WEB");
        });

        modelBuilder.Entity<PageView>(entity =>
        {
            entity.ToTable("PageView");

            entity.HasIndex(e => e.CreatedAt, "IX_PageView_CreatedAt").IsDescending();

            entity.HasIndex(e => e.SessionId, "IX_PageView_SessionId");

            entity.HasIndex(e => e.Url, "IX_PageView_Url");

            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Device).HasMaxLength(50);
            entity.Property(e => e.IpAddress).HasMaxLength(50);
            entity.Property(e => e.Referrer).HasMaxLength(500);
            entity.Property(e => e.SessionId).HasMaxLength(100);
            entity.Property(e => e.Url).HasMaxLength(500);
            entity.Property(e => e.UserAgent).HasMaxLength(200);
            entity.Property(e => e.UtmCampaign).HasMaxLength(200);
            entity.Property(e => e.UtmMedium).HasMaxLength(100);
            entity.Property(e => e.UtmSource).HasMaxLength(100);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC07B7191300");

            entity.ToTable("Post");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Slug).HasMaxLength(255);
            entity.Property(e => e.ThumbUrl).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<PostCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostCate__3214EC0787947E65");

            entity.ToTable("PostCategory");

            entity.Property(e => e.IsPublished).HasDefaultValue(1);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Slug).HasMaxLength(255);
            entity.Property(e => e.ThumbUrl).HasMaxLength(500);
        });

        modelBuilder.Entity<PostVersion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostVers__3214EC07988113EE");

            entity.ToTable("PostVersion");

            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductI__3214EC072DF8211E");

            entity.ToTable("ProductImage");

            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.ImagePath).HasMaxLength(255);
            entity.Property(e => e.ImageType).HasMaxLength(50);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.HasIndex(e => e.Name, "UQ_Role_Name").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ShopCategory>(entity =>
        {
            entity.ToTable("ShopCategory");

            entity.HasIndex(e => e.Slug, "UQ_ShopCategory_Slug").IsUnique();

            entity.Property(e => e.CategoryName).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MetaDescription).HasMaxLength(300);
            entity.Property(e => e.MetaKeywords).HasMaxLength(500);
            entity.Property(e => e.MetaTitle).HasMaxLength(150);
            entity.Property(e => e.Photo).HasMaxLength(500);
            entity.Property(e => e.ShopCode).HasMaxLength(10);
            entity.Property(e => e.Slug)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SortOrder).HasDefaultValue(0);
        });

        modelBuilder.Entity<ShopProduct>(entity =>
        {
            entity.ToTable("ShopProduct");

            entity.HasIndex(e => e.Sku, "UQ_ShopProduct_SKU").IsUnique();

            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Dimension).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsFeatured).HasDefaultValue(false);
            entity.Property(e => e.LocationCode).HasMaxLength(50);
            entity.Property(e => e.LowStockThreshold).HasDefaultValue(5);
            entity.Property(e => e.MetaDescription).HasMaxLength(300);
            entity.Property(e => e.MetaKeywords).HasMaxLength(500);
            entity.Property(e => e.MetaTitle).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Photo).HasMaxLength(500);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ShopCode).HasMaxLength(10);
            entity.Property(e => e.Sku)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SKU");
            entity.Property(e => e.Slug).HasMaxLength(255);
            entity.Property(e => e.StockQuantity).HasDefaultValue(0);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.Weight).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<ShopProductImage>(entity =>
        {
            entity.ToTable("ShopProductImage");

            entity.Property(e => e.AltText).HasMaxLength(255);
            entity.Property(e => e.ImagePath).HasMaxLength(500);
            entity.Property(e => e.ImageType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SortOrder).HasDefaultValue(0);
        });

        modelBuilder.Entity<SiteContent>(entity =>
        {
            entity.HasKey(e => e.ContentId).HasName("PK__SiteCont__2907A81E2BC27C66");

            entity.ToTable("SiteContent");

            entity.Property(e => e.ContentKey).HasMaxLength(200);
            entity.Property(e => e.ContentType).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<StaticContent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StaticCo__3214EC0797F61A55");

            entity.ToTable("StaticContent");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Key).HasMaxLength(200);
            entity.Property(e => e.MetaDescription).HasMaxLength(500);
            entity.Property(e => e.MetaKeywords).HasMaxLength(500);
            entity.Property(e => e.MetaTitle).HasMaxLength(200);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<StaticPage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StaticPa__3214EC072598DBF0");

            entity.HasIndex(e => e.Slug, "UQ__StaticPa__BC7B5FB6EBD0652A").IsUnique();

            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Content).HasColumnType("ntext");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MetaDescription).HasMaxLength(500);
            entity.Property(e => e.MetaKeywords).HasMaxLength(500);
            entity.Property(e => e.MetaTitle).HasMaxLength(200);
            entity.Property(e => e.Photo)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Slug).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<SystemWidthBlogProduct>(entity =>
        {
            entity.ToTable("SystemWidthBlogProduct");

            entity.HasIndex(e => e.Sku, "IX_SystemWidthBlogProduct_Sku").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Sku).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tag__3214EC074DAA060E");

            entity.ToTable("Tag");

            entity.HasIndex(e => e.Slug, "UQ__Tag__BC7B5FB64BD9A79F").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Slug)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TextEditorMediaItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TextEdit__3214EC07CB072C0F");

            entity.ToTable("TextEditorMediaItem");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<VisitorSession>(entity =>
        {
            entity.ToTable("VisitorSession");

            entity.HasIndex(e => e.SessionId, "IX_VisitorSession_SessionId");

            entity.HasIndex(e => e.StartedAt, "IX_VisitorSession_StartedAt").IsDescending();

            entity.HasIndex(e => e.SessionId, "UQ_VisitorSession_SessionId").IsUnique();

            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.Device).HasMaxLength(50);
            entity.Property(e => e.EndedAt).HasColumnType("datetime");
            entity.Property(e => e.FirstPage).HasMaxLength(500);
            entity.Property(e => e.IpAddress).HasMaxLength(50);
            entity.Property(e => e.LastPage).HasMaxLength(500);
            entity.Property(e => e.PageCount).HasDefaultValue(1);
            entity.Property(e => e.SessionId).HasMaxLength(100);
            entity.Property(e => e.StartedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UtmCampaign).HasMaxLength(200);
            entity.Property(e => e.UtmMedium).HasMaxLength(100);
            entity.Property(e => e.UtmSource).HasMaxLength(100);
        });

        modelBuilder.Entity<Wishlist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Wishlist__3214EC0789FB8F04");

            entity.HasIndex(e => e.TokenShare, "UQ__Wishlist__00201C7C092126C7").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.TokenShare).HasMaxLength(50);
        });

        modelBuilder.Entity<WishlistItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Wishlist__3214EC07AE489423");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<ZaloNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ZaloNoti__3214EC071FBE8DE8");

            entity.ToTable("ZaloNotification");

            entity.Property(e => e.SentAt).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TemplateId).HasMaxLength(50);
            entity.Property(e => e.ZaloUserId).HasMaxLength(100);
        });

        modelBuilder.Entity<ZaloToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ZaloToke__3214EC07911F110F");

            entity.ToTable("ZaloToken");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ExpiredAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<ZaloUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ZaloUser__3214EC07E3ED9252");

            entity.ToTable("ZaloUser");

            entity.Property(e => e.FollowedAt).HasColumnType("datetime");
            entity.Property(e => e.LastInteractionAt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.ZaloUserId).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
