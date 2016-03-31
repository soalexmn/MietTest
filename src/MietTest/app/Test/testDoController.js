mietTestApp.controller('testDoController',
    ["$scope", "$window", "genericService",
function testDoController($scope, $window, genericService) {

    $scope.test = {};
    $scope.testResult = {};

    $scope.testId = -1;
    $scope.guid = "";
    $scope.selected = {};
    $scope.currentQuestion = {};
    $scope.currentQuestionResult = {};
    $scope.currentIndex = -1;

    $scope.initialLoad = function (id, guid) {
        $scope.testId = id;
        $scope.guid = guid;
        $scope.loadTest();
        $scope.loadResult();
    }

    $scope.changeIndex = function (index) {
        $scope.currentIndex = index;
        $scope.currentQuestion = $scope.test.Questions[index];
        $scope.currentQuestionResult = $scope.testResult.QuestionResults[index];
    }

    $scope.copyObject = function (object) {
        return angular.copy(object);
    }

    $scope.loadTest = function () {
        genericService.customQuery('/Test/GetTest?id=' + $scope.testId).then(
                function (results) {
                    // on success
                    $scope.test = results.data;
                },
                function (results) {
                    // on error
                    //alertService.showAlert(results);
                    $scope.hasFormError = true;
                });
    }

    $scope.loadResult = function () {
        genericService.customQuery('/Test/GetTestResult?s=' + $scope.guid).then(
                function (results) {
                    // on success
                    $scope.testResult = results.data;
                },
                function (results) {
                    // on error
                    //alertService.showAlert(results);
                    $scope.hasFormError = true;
                });
    }



    var findById = function (array, id) {
        return array.filter(function (obj) { return obj.Id == id; })[0];
    };

    var indexById = function (array, id) {
        return array.indexOf(array.filter(function (obj) { return obj.Id == id; })[0]);
    };

}]);