define(["knockout", "dataservice"], function (ko, ds) {
    return function (params) {

        let bookmarkedPerson = ko.observable([]);

        ds.getUserBookmarkedPerson(function (status) {
            console.log(status);
            if (status != "Unauthorized")
                bookmarkedPerson(status);
        });

        return {
            bookmarkedPerson
        }
    }
});