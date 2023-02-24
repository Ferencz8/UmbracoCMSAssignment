(function () {
    'use strict';
    console.log('Works');
    function hooksController($scope) {

        var vm = this;

        vm.hookSite = "";

        vm.buttonState = "init";

        vm.saveSite = saveSite;

        function saveSite() {

            vm.buttonState = "busy";

            var url = "api/HooksApi/Save";
            var hookUrlSite = document.getElementById("hookSite").value;
            var params = { "site": hookUrlSite };
            var xhr = new XMLHttpRequest();
            xhr.open("POST", url, true);

            //Send the proper header information along with the request
            xhr.setRequestHeader("Content-type", "application/json");

            xhr.send(JSON.stringify(params));

            xhr.onload = function () {
                if (xhr.status === 200) {
                    vm.buttonState = "success";
                    console.log("It worked!");
                } else if (xhr.status === 404) {
                    console.log("No records found")
                    vm.buttonState = "error";
                }
            }
        }

        function getHookSite () {
            var url = "api/HooksApi/Get";            
            var xhr = new XMLHttpRequest();
            xhr.open("GET", url, true);

            //Send the proper header information along with the request
            xhr.setRequestHeader("Content-type", "application/json");

            xhr.send();

            xhr.onload = function () {
                if (xhr.status === 200) {                    
                    console.log("It worked!");
                    vm.hookSite = xhr.response;
                    //workarround
                    document.getElementById("hookSite").value = vm.hookSite;
                } else if (xhr.status === 404) {
                    console.log("No records found")
                }
            }
        }
        getHookSite();

        vm.page = {
            title: 'Hooks'
        }

        function selectAll($event) {
            alert("select all");
        }

        function isSelectedAll() {

        }

        function clickItem(item) {
            console.log(item);
            alert("click node");
        }

        function selectItem(selectedItem, $index, $event) {
            alert("select node");
        }

        function isSortDirection(col, direction) {

        }

        function sort(field, allow, isSystem) {

        }


        vm.selectItem = selectItem;
        vm.clickItem = clickItem;
        vm.selectAll = selectAll;
        vm.isSelectedAll = isSelectedAll;
        vm.isSortDirection = isSortDirection;
        vm.sort = sort;
    };

    angular.module('umbraco')
        .controller('HooksController', hooksController);
})();
