define(["knockout", "dataservice"], function (ko, ds) {
    return function (params) {

        let bookmarkedTitles = ko.observable([]);

        ds.getUserBookmarkedTitles(function (status) {
            console.log(status);
            bookmarkedTitles(status);

        });

        return {
            bookmarkedTitles
        }
    }
});