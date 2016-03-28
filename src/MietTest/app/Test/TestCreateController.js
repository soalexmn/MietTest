mietTestApp.controller('testCreateController',
    ["$scope", "$window", "genericService",
function testCreateController($scope, $window, genericService) {

    $scope.test = { Questions: [] };

    $scope.currentQuestion = {};
    $scope.currentIndex = -1;

    $scope.addQuestion = function () {
        $scope.test.Questions.push({ AnswerVariants: [] });
        $scope.changeIndex($scope.test.Questions.length - 1);
    }

    $scope.addVariant = function () {
        $scope.currentQuestion.AnswerVariants.push({});
    };

    $scope.removeVariant = function (index) {
        $scope.currentQuestion.AnswerVariants.splice(indexById($scope.currentQuestion.AnswerVariants, index), 1);
    }

    $scope.changeIndex = function (index) {
        $scope.currentIndex = index;
        $scope.currentQuestion = $scope.test.Questions[index];
    }

    $scope.copyObject = function (object) {
        return angular.copy(object);
    }

    $scope.createTest = function () {
        genericService.customQuery('/Test/createTest', $scope.test).then(
                function (results) {
                    // on success
                    $window.location.href = "";
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