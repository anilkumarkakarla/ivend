/// <binding BeforeBuild='client-orchestrator-scripts' ProjectOpened='client-orchestrator-serve' />

var gulp = require('gulp');
var $ = require('gulp-load-plugins')({ pattern: ['gulp-*'] });
var isLocal = true;

gulp.task('client-orchestrator-scripts', function () {

    return gulp.src(['CXS.Framework.UI.Core/js/pos.primary.js', 'CXS.Framework.UI.Core/js/{models,directives}/*.js'])
    .pipe($.ngAnnotate()).on('error', _swallowError)
    .pipe($.if(!isLocal, $.uglify())).on('error', _swallowError)
    .pipe($.concat('app.js'))
    .pipe(gulp.dest('CXS.Framework.UI.Sample'));
});

gulp.task('client-orchestrator-serve', function () {
    gulp.watch('CXS.Framework.UI.Core/js/**/*.js', ['client-orchestrator-scripts']);
});

/**
 * Swallows stream error and ends stream
 */
function _swallowError(err) {
    console.error(err);
    this.emit('end');
}
