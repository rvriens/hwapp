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

var paths = {
    scripts: ['scripts/**/*.js', 'scripts/**/*.ts', 'scripts/**/*.map'],
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

gulp.task('build:js', function () {
    gulp.src(paths.scripts)
    .pipe(tsc(tsProject)).js
    .pipe(gulp.dest('wwwroot/scripts'));
});

gulp.task("build:dotnet", function(cb) {
    Dotnet.build({ cwd: './' }, cb);
});