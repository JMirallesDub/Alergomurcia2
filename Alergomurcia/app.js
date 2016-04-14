var app = angular.module('MyApp', ['angularUtils.directives.dirPagination', 'ngSanitize']);

app.factory('crudServiceMeet', function ($http) {
    crudMeetObj = {};

    crudMeetObj.getAll = function () {
        var Meets;
        Meets = $http({ method: 'Get', url: '/reuniones/index' }).
        then(function (response) {
            return response.data;
        });
        return Meets;
    }

    crudMeetObj.GetById = function (id) {
        var Meet;
        Meet = $http({ method: 'Get', url: '/reuniones/details', params:{id:id} }).
        then(function (response) {
            return response.data;
        });
        return Meet;
    }

    return crudMeetObj;
});

app.controller('reunionesController', function ($scope, crudServiceMeet) {
    crudServiceMeet.getAll().then(function (result) {
        $scope.Meets = result;
    })

    $scope.GetById = function (id) {
        crudServiceMeet.GetById(id).then(function (result) {
            $scope.Meet = result;
        });
    };
});

app.filter("jsDate", function () {
    return function (x) {
        return new Date(parseInt(x.substr(6)));
    };
});

app.filter("sanitize", ['$sce', function ($sce) {
    return function (htmlCode) {
        return $sce.trustAsHtml(htmlCode);
    }
}]);