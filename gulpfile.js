/// <binding AfterBuild='default' Clean='clean' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var del = require('del');
var tslint = require("gulp-tslint");
var tsc = require("gulp-typescript");
var Dotnet = require('gulp-dotnet');

// var uglify = require('gulp-uglify');
var pump = require('pump');

var paths = {
    scripts: ['scripts/**/*.js', 'scripts/**/*.ts', 'scripts/**/*.map', 'scripts/**/*.tsx']
};

var tsProject = tsc.createProject("scripts/tsconfig.json");

gulp.task("clean", ["clean:js", "clean:dotnet"]);

gulp.task('clean:js', function (cb) {
    return del(['wwwroot/scripts/**/*']);
});

gulp.task('clean:dotnet', function (cb) {
    return del(['bin/**/*']);
});

gulp.task("build", ["build:js", "build:dotnet"]);

gulp.task('build:js', ["copy-assets"], function (cb) {
    /*pump([
        gulp.src(paths.scripts),
        ,        
        gulp.dest('wwwroot/scripts')
    ],
        cb
    );*/
    gulp.src(paths.scripts)
    .pipe(tsc(tsProject)).js
    .pipe(gulp.dest('wwwroot/scripts'));

    
});

var _    = require('lodash');

gulp.task('copy-assets', function() {
    var assets = {
        js: [
            './node_modules/react/dist/react-with-addons.js',
            './node_modules/react-dom/dist/react-dom.js',
            './libs/js/require.js'
        ],
        css: []
    };
    _(assets).forEach(function(assets, type) {
        gulp.src(assets).pipe(gulp.dest('./wwwroot/lib/' + type));
    });
});



gulp.task("build:dotnet", ["clean:dotnet"], function (cb) {
    Dotnet.build({ cwd: './' }, cb);
});