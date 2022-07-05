namespace Product.API.Extentions
{
    public static class ApplicationExtions
    {
        public static void UseInfastructure(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRouting();
            // app.UseHttpsRedirection(); //for production only

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
