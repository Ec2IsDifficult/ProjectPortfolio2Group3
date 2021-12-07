define(["knockout", "dataservice"], function (ko, ds) {
    return function(params){
        let titleCardList = ko.observable("title-card-list");
        let personCardList = ko.observable("person-card-list");


        return {
            titleCardList: titleCardList,
            personCardList: personCardList
        }
    }
});