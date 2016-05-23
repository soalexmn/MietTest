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

        if ($scope.currentIndex >= 0) {
            if ($scope.currentQuestion.QuestionType == 0) {
                $scope.currentQuestionResult.Result = $scope.currentQuestion.Result;
            }
            else if ($scope.currentQuestion.QuestionType == 1) {
                var result = [];
                for (var i = 0; i < $scope.currentQuestion.AnswerVariants.length; i++) {
                    var variant = $scope.currentQuestion.AnswerVariants[i];
                    if (variant.Result == true) {
                        result.push(i);
                    }

                }
                $scope.currentQuestionResult.Result = result.join();
            }
        }

        $scope.currentIndex = index;
        $scope.currentQuestion = $scope.test.Questions[index];

        if ($scope.testResult.QuestionResults[index] == undefined && index >= 0) {
            var questionResult = { QuestionId: $scope.currentQuestion.Id };
            $scope.testResult.QuestionResults[index] = questionResult;
        }
        if (index >= 0) {
            $scope.currentQuestionResult = $scope.testResult.QuestionResults[index];
            if ($scope.currentQuestion.QuestionType == 0) {
                $scope.currentQuestion.Result = $scope.currentQuestionResult.Result;
            }
            else if ($scope.currentQuestion.QuestionType == 1) {
                var result = $scope.currentQuestionResult.Result.split(',');
                for (var i = 0; i < result.length; i++) {
                    $scope.currentQuestion.AnswerVariants[result[i]].Result = true;
                }

            }
        }
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

    $scope.updateResult = function () {
        genericService.customQuery('/Test/UpdateTestResult', { Guid: $scope.guid, Test: $scope.testResult }).then(
                function (results) {
                    // on success
                },
                function (results) {
                    // on error
                    //alertService.showAlert(results);
                    $scope.hasFormError = true;
                });
    }

    $scope.doneTest = function () {
        genericService.customQuery('/Test/DoneTest', { Guid: $scope.guid, Test: $scope.testResult }).then(
                function (results) {
                    // on success
                    $window.location = '/Test/Result?id' + results.data.Id;
                },
                function (results) {
                    // on error
                    //alertService.showAlert(results);
                    $scope.hasFormError = true;
                });
    };


    $scope.loadResultVerified = function (id) {
        genericService.customQuery('/Test/GetResult?id=' + id).then(
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