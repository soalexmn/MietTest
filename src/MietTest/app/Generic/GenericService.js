mietTestApp.factory("genericService",
 ["$http",
     function ($http) {

         var getAll = function (controllerName) {
             return $http.get("/" + controllerName + "/GetAll");
         };

         var deleteEntity = function (controllerName, entity) {
             return $http.post("/" + controllerName + "/Delete", entity);
         };

         var updateEntity = function (controllerName, entity) {
             return $http.post("/" + controllerName + "/Update", entity);
         };

         var addEntity = function (controllerName, entity) {
             return $http.post("/" + controllerName + "/Add", entity);
         };

         var getPage = function (controllerName, orderBy, reverse, page, itemsPerPage) {
             return $http.post("/" + controllerName + "/GetPage", { OrderBy: orderBy, IsReverse: reverse, PageNumber: page, ItemsPerPage: itemsPerPage });
         };

         var customQuery = function (query, model) {
             if (model == undefined) {
                 return $http.get(query);
             }
             else {
                 return $http.post(query, model);
             }
         };

         return {
             getAll: getAll,
             deleteEntity: deleteEntity,
             updateEntity: updateEntity,
             addEntity: addEntity,
             customQuery: customQuery,
             getPage: getPage
         };
     }]);