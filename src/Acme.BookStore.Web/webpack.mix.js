let mix = require("laravel-mix");

/*
 |--------------------------------------------------------------------------
 | Mix Asset Management
 |--------------------------------------------------------------------------
 |
 | Mix provides a clean, fluent API for defining some Webpack build steps
 | for your Laravel application. By default, we are compiling the Sass
 | file for your application, as well as bundling up your JS files.
 |
 | API Documentation: https://laravel-mix.com/docs
 */

if (!mix.inProduction()) {
    mix.webpackConfig({ devtool: "source-map" });
}

mix.setPublicPath("wwwroot");

mix.sass("./Styles/site.scss", "css/site.css");
mix.vue()
    //.js("./Scripts/Services/serviceBuilder.js", "js/site.js")
    .js(["./Scripts/Example/exampleIndexPageBuilder.js"], "js/exampleIndex.js")

