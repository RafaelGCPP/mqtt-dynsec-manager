﻿using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using mqtt_dynsec_manager.Models;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.EntityFramework.Entities;

namespace mqtt_dynsec_manager.Data;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Key>()
            .Property(d => d.Data)
            .HasMaxLength(4000)
            .HasColumnType("NVARCHAR2(4000)");
    }
}
