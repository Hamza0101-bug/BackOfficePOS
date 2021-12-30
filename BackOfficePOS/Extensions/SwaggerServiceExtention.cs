namespace BackOfficePOS.Extensions
{
    public static class SwaggerServiceExtention
    {
        public static IServiceCollection AddSwaggerDocumention(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            return services;

        }
        public static IApplicationBuilder UseSwaagerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.jason", "Api v1"));
            return app;

        }
    }
}