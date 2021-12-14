define(["knockout", "dataservice", "viewmodel"], function (ko, ds, vm) {
    return function (params) {
        let randomTitles = ko.observableArray([]);

        let nextPage = ko.observable();
        let nextPageUrl = "";
        let prevPage = ko.observable();
        let prevPageUrl = ko.observable();
        let showButtonDiv = ko.observable(true);

        if(params.show === "dontShow")
            showButtonDiv(false)
        delete params.show
        let args = Object.values(params).splice(1)
        let execute = function (url) {
            params.func(data => {
                if (data.data) {

                    return_data = data.data;

                    /**
                     * Check if image exists
                     */
                    for (var k in return_data) {
                        exist = false;

                        if (return_data[k].awards != null && return_data[k].awards != undefined && return_data[k].awards != 'N/A')
                            exist = imageExists(return_data[k].awards);

                        if (!exist) {
                            return_data[k].awards = "image/plain-bg.jpeg";
                        }
                    }

                    randomTitles(data.data);
                    nextPage(data.nextPage)
                    prevPage(data.previousPage)
                    nextPageUrl = data.nextPage;
                    prevPageUrl = data.previousPage;
                }
                else {
                    return_data = data;

                    /**
                     * Check if image exists
                     */
                    for (var k in return_data) {
                        exist = false;

                        if (return_data[k].awards != null && return_data[k].awards != undefined && return_data[k].awards != 'N/A')
                            exist = imageExists(return_data[k].awards);

                        if (!exist) {
                            return_data[k].awards = "image/plain-bg.jpeg";
                        }
                    }

                    randomTitles(data)
                }
            }, ...args, url);
        }

        execute();
        let goToNextPage = () => {
            console.log(nextPageUrl)
            execute(nextPageUrl)
        }

        let goToPrevPage = () => {
            console.log(prevPageUrl)
            execute(prevPageUrl)
        }
        
        let goToSpecificTitle = (tconst) => {
            vm.changeContent(vm.componentItems.find(item => item.component === "titles-page"));
            vm.currentParams(tconst);

        }

        /**
         * Sourced from
         * https://stackoverflow.com/questions/18837735/
         */
        let imageExists = function (image_url) {

            var http = new XMLHttpRequest();

            http.open('HEAD', image_url, false);
            http.send();

            return http.status != 404;

        }

        return {
            randomTitles: randomTitles,
            nextPage: nextPage,
            prevPage: prevPage,
            goToNextPage: goToNextPage,
            goToPrevPage: goToPrevPage,
            showButtonDiv:showButtonDiv,
            goToSpecificTitle:goToSpecificTitle
        }
    }
});