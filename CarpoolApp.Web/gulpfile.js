var gulp = require('gulp');
var del = require('del');
var runsequence = require('run-sequence');
var folders = {
    src: 'bower_components/',
    dest: 'scripts/vendor/'
}

gulp.task('copy', function () {
    var files = {
        'bootstrap': 'bootstrap/dist/css/bootstrap.min.*',
        'jquery': 'jquery/dist/jquery.min.*',
        'angular': 'angular/angular.min.*',
        'angular-bootstrap': 'angular-bootstrap/ui-bootstrap-tpls.min.js',
        'angular-ui-router': 'angular-ui-router/release/angular-ui-router.min.js',
        'angular-resource': 'angular-resource/angular-resource.min.*',
        'angular-loading-bar': 'angular-loading-bar/build/loading-bar.min.*',
        'toastr': 'toastr/toastr.min.*',
        'angular-local-storage': 'angular-local-storage/dist/angular-local-storage.min.*'
    };

    for (file in files) {
        gulp.src(folders.src + files[file])
            .pipe(gulp.dest(folders.dest + file));
    }

    gulp.src(folders.src + 'bootstrap/dist/js/bootstrap.min.*')
        .pipe(gulp.dest(folders.dest + 'bootstrap'));
    gulp.src(folders.src + 'angular-mocks/angular-mocks.js')
        .pipe(gulp.dest('scripts/tests/unit'));
});

gulp.task('clear', function () {
    return del.sync(folders.dest);
});

gulp.task('build', function () {
    runsequence('clear', 'copy');
});