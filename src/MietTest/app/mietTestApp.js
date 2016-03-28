var mietTestApp = angular.module('mietTestApp', [ 'ui.bootstrap']);



mietTestApp.config(
    function ($locationProvider) {
        $locationProvider.html5Mode(true);

    });