// Karma configuration
// Generated on Mon Oct 03 2016 14:20:16 GMT+0530 (India Standard Time)

module.exports = function(config) {
  config.set({

    // base path that will be used to resolve all patterns (eg. files, exclude)
    basePath: '../..',


    // frameworks to use
    // available frameworks: https://npmjs.org/browse/keyword/karma-adapter
    frameworks: ['jasmine'],


    // list of files / patterns to load in the browser
    files: [
        'vendor/angular/angular.min.js',
        'tests/unit/angular-mocks.js',
        'vendor/jquery/jquery.min.js',
       'vendor/**/*.js',
       'app/*.js',
       'app/**/*.js',
       'app/**/**/*.js',
       //'tests/unit/*.js',
       'tests/unit/**/*.js'
    ],

    plugins: [
    'karma-chrome-launcher',    
    'karma-jasmine',
    'karma-spec-reporter'    
    ],

    // list of files to exclude
    exclude: [
    ],


    // preprocess matching files before serving them to the browser
    // available preprocessors: https://npmjs.org/browse/keyword/karma-preprocessor
    preprocessors: {
    },


    // test results reporter to use
    // possible values: 'dots', 'progress'
    // available reporters: https://npmjs.org/browse/keyword/karma-reporter
    reporters: ['spec'],

    specReporter: {
        maxLogLines: 5,         // limit number of lines logged per test 
        suppressErrorSummary: true,  // do not print error summary 
        suppressFailed: false,  // do not print information about failed tests 
        suppressPassed: false,  // do not print information about passed tests 
        suppressSkipped: true,  // do not print information about skipped tests 
        showSpecTiming: false // print the time elapsed for each spec 
    },

    // web server port
    port: 9876,


    // enable / disable colors in the output (reporters and logs)
    colors: true,


    // level of logging
    // possible values: config.LOG_DISABLE || config.LOG_ERROR || config.LOG_WARN || config.LOG_INFO || config.LOG_DEBUG
    logLevel: config.LOG_INFO,


    // enable / disable watching file and executing tests whenever any file changes
    autoWatch: false,


    // start these browsers
    // available browser launchers: https://npmjs.org/browse/keyword/karma-launcher
    browsers: ['Chrome'],


    // Continuous Integration mode
    // if true, Karma captures browsers, runs the tests and exits
    singleRun: true,

    // Concurrency level
    // how many browser should be started simultaneous
    concurrency: Infinity
  })
}
