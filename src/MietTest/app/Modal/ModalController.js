mietTestApp.factory('modalService', ["$modal", function ($modal) {


    var openInputDialog = function (modalMessage, size, init) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/app/Modal/modalInputDialog.html',
            controller: 'modalInstanceInputController',
            size: size,
            resolve: {
                modalMessage: function () {
                    return modalMessage;
                },
                init: function () {
                    return init;
                }
            }
        });
        return modalInstance.result;
    }

    //можно вызывать без size или с параметрами lg, sm
    var openDeleteDialog = function (modalMessage, size, checkPassword) {
        var modalInstance;
        if (checkPassword == undefined || false) {
            modalInstance = $modal.open({
                animation: true,
                templateUrl: '/app/Modal/modalDeleteDialog.html',
                controller: 'modalInstanceController',
                size: size,
                resolve: {
                    modalMessage: function () {
                        return modalMessage;
                    }
                }
            });
            return modalInstance.result;
        }
        else {
            modalInstance = $modal.open({
                animation: true,
                templateUrl: '/app/Modal/modalDeleteDialogPass.html',
                controller: 'modalInstanceController',
                size: size,
                resolve: {
                    modalMessage: function () {
                        return modalMessage;
                    }
                }
            });
            return modalInstance.result;
        }
    };

    var openCustomDeleteDialog = function (modalMessage, size, checkPassword) {
        var modalInstance;
        if (checkPassword == undefined || false) {
            modalInstance = $modal.open({
                animation: true,
                templateUrl: '/app/Modal/modalCustomDeleteDialog.html',
                controller: 'modalInstanceController',
                size: size,
                resolve: {
                    modalMessage: function () {
                        return modalMessage;
                    }
                }
            });
            return modalInstance.result;
        }
        else {
            modalInstance = $modal.open({
                animation: true,
                templateUrl: '/app/Modal/modalDeleteDialogPass.html',
                controller: 'modalInstanceController',
                size: size,
                resolve: {
                    modalMessage: function () {
                        return modalMessage;
                    }
                }
            });
            return modalInstance.result;
        }
    };


    return {
        openDeleteDialog: openDeleteDialog,
        openCustomDeleteDialog: openCustomDeleteDialog,
        openInputDialog: openInputDialog
    };
}]);


mietTestApp.controller("modalInstanceController", ["$scope", "$modalInstance", "modalMessage", function ($scope, $modalInstance, modalMessage) {

    $scope.modalMessage = modalMessage;

    $scope.ok = function () {
        if ($scope.password == undefined) {
            $modalInstance.close();
        }
        else {
            $modalInstance.close($scope.password);
        }
    };

    $scope.cancel = function () {
        $modalInstance.dismiss("cancel");
    };
}]);

mietTestApp.controller("modalInstanceInputController", ["$scope", "$modalInstance", "modalMessage", "init", function ($scope, $modalInstance, modalMessage, init) {

    $scope.modalMessage = modalMessage;
    $scope.password = init;

    $scope.ok = function () {
        if ($scope.password == undefined) {
            $modalInstance.close();
        }
        else {
            $modalInstance.close($scope.password);
        }
    };

    $scope.cancel = function () {
        $modalInstance.dismiss("cancel");
    };
}]);