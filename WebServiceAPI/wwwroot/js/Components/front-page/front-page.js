define(["knockout", "dataservice"], function (ko,ds) {
    return function(params){
        let titleCardList = ko.observable("title-card-list");
        let personCardList = ko.observable("person-card-list");
        let leftArrow = ko.observable("left-arrow");
        let rightArrow = ko.observable("right-arrow");



        return {
            titleCardList: titleCardList,
            personCardList: personCardList,
            leftArrow: leftArrow,
            rightArrow: rightArrow,
            
            getTitles: ds.getRandomTitles,
            getPeople: ds.getRandomPeople
        }
    }
});