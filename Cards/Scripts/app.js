//ShowSet details slide down
$("#showset-description-show").click(function () {
    $("#showset-description").slideDown("fast", function () {        
    });
    $("#showset-description-show").css("display", "none");
});

//ShowSet details slide up
$("#close-description-button").click(function () {
    $("#showset-description").slideUp("fast", function () {
    });
    setTimeout(() => {
        $("#showset-description-show").css("display", "block");
    }, 130)
});

//////Test mode
//Flipping
let flipped = false;

$(".test-card").click(() => {
    if (!flipped) {
        $(".test-card-front").addClass("flip-front").removeClass("unflip-front");
        $(".test-card-back").addClass("flip-back").removeClass("unflip-back");
        flipped = true;
    } else {
        $(".test-card-front").addClass("unflip-front").removeClass("flip-front");
        $(".test-card-back").addClass("unflip-back").removeClass("flip-back");
        flipped = false;
    }    
})

//Card cycle
let nextCount = 0;
let prevCount;
let maxCount = $("#cards-container").children().length;

function ShowCard(x) { //Despite name, refers to car
    let cardList = $("#cards-container").children();
    cardList.each((item, element) => {
        let id = parseInt(element.id.substr(5));
        if (id == x) {
            console.log("(ShowCard) Id Matched:", id)
            element.removeAttribute('class');            
        };     
    })
    
}

function HideCard(x) { 
    let cardList = $("#cards-container").children();
    cardList.each((item, element) => {
        let id = parseInt(element.id.substr(5));
        if (id == x) {
            console.log("(HideCard) Id Matched:", id)
            element.setAttribute("class", "inactive");
        };
    })
}

$(".back-btn").click(() => {
    if (nextCount - 1 >= 0) {
        prevCount = nextCount;
        nextCount -= 1;
        ShowCard(nextCount);
        HideCard(prevCount);
        //Flip all cards back over
        $(".test-card-front").addClass("unflip-front").removeClass("flip-front");
        $(".test-card-back").addClass("unflip-back").removeClass("flip-back");
    } else {
        console.error("There's no card before this one")
    }
})

$(".fwd-btn").click(() => {
    if (nextCount <= maxCount -2) {
        prevCount = nextCount;
        nextCount += 1;
        ShowCard(nextCount);
        HideCard(prevCount);
        //Flip all cards back over
        $(".test-card-front").addClass("unflip-front").removeClass("flip-front");
        $(".test-card-back").addClass("unflip-back").removeClass("flip-back");
    } else {
        console.error("There's no card after this one")
    }
})