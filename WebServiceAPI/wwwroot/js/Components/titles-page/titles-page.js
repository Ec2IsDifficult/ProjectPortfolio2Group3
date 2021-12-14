define(["knockout", "dataservice"],
    function (ko, ds) {
return function(params) {
    let selectedTitle = ko.observable(params);
    
    let cast = ko.observable([]);
 

    ds.getCast(selectedTitle(),function(data) {
        cast(data.cast);
    })
    let titleRating = ko.observable();
    let checkVotes = ko.observable('False');
    
    
    ds.getTitleRating(selectedTitle(), function (data) {
        if(data.numVotes > 0){
            checkVotes('True');
        }
        console.log(data);
        titleRating(data);
    })

    let crew = ko.observable([]);
    
    ds.getCrew(selectedTitle(), function (data) {
        console.log(data.crew)
        crew(data.crew);
    })

    ds.getTitle(selectedTitle(), async function (data) {
        console.log(data);
        title(data);
        if (data.awards !== null) {
            await getTitlePoster(data.awards);
        }
    })

    let title = ko.observable();

    

    let getTitlePoster = (_url) => ds.getPoster(_url);
    
    return {
        selectedTitle,
        titleRating,
        //getTitleRating,
        crew,
        //getTitleCrew,
        title,
        //getSingleTitle,
        cast,
        //getCast,
        checkVotes,
        //getTitlePoster
    }
    }})