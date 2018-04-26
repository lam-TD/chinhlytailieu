var app = angular.module("appchinhlytailieu", ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider
    .when('/', {
        templateUrl: '../phanheQLthuthapTL',
        controller: 'phanheQLthuthapTLController'
    })
    .when('/lapkehoachchinhly', {
        templateUrl: '../lapkehoachchinhly',
        controller: 'lapkehoachchinhlyController'
    })
    .when('/taomucluc', {
        templateUrl: '../taomucluc',
        controller: 'taomuclucController'
    })
    .when('/nhaphoso', {
        templateUrl: '../nhaphoso',
        controller: 'nhaphosoController'
    })
    .when('/nhaphoso/them', {
        templateUrl: '../nhaphosothem',
        controller: 'nhaphosoController'
    })
    .when('/nhapvanban', {
        templateUrl: '../nhapvanban',
        controller: 'nhapvanbanController'
    })
    .when('/importhoso', {
        templateUrl: '../importhoso',
        controller: 'nhapvanbanController'
    })
    .when('/importvanban', {
        templateUrl: '../importvanban',
        controller: 'nhapvanbanController'
    })
    .when('/taohop', {
        templateUrl: '../taohop',
        controller: 'nhapvanbanController'
    })
    .when('/xephosovaohop', {
        templateUrl: '../xephosovaohop',
        controller: 'nhapvanbanController'
    })
    .when('/kiemtrahosochinhly', {
        templateUrl: '../kiemtrahosochinhly',
        controller: 'nhapvanbanController'
    })
    .when('/giaotailieuvaokho', {
        templateUrl: '../giaotailieuvaokho',
        controller: 'nhapvanbanController'
    })
})