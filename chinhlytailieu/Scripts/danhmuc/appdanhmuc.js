var app = angular.module("appdanhmuc", ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider
    .when('/', {
        templateUrl: '../coquanluutru',
        controller: 'phanheQLthuthapTLController'
    })
    .when('/phongtailieu', {
        templateUrl: '../phongtailieu',
        controller: 'lapkehoachchinhlyController'
    })
    .when('/loaihinhtailieu', {
        templateUrl: '../loaihinhtailieu',
        controller: 'taomuclucController'
    })
    .when('/thoihanbaoquan', {
        templateUrl: '../thoihanbaoquan',
        controller: 'nhaphosoController'
    })
    .when('/tudien', {
        templateUrl: '../tudien',
        controller: 'nhaphosoController'
    })
    .otherwise({
        redirectTo: '/'
    })
})