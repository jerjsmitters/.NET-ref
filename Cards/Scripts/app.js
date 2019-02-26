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

$("#test-card").click(() => {
    if (!flipped) {
        $("#test-card-front").addClass("flip-front").removeClass("unflip-front");
        $("#test-card-back").addClass("flip-back").removeClass("unflip-back");
        flipped = true;
    } else {
        $("#test-card-front").addClass("unflip-front").removeClass("flip-front");
        $("#test-card-back").addClass("unflip-back").removeClass("flip-back");
        flipped = false;
    }    
})

//Card cycle
function increaseByOne() {
    var startElement = $("#counterVar");
    var value = parseInt(startElement.val(), 10);
    startElement.val(value + 1);
}

function decreaseByOne() {
    var startElement = $("#counterVar");
    var value = parseInt(startElement.val(), 10);
    startElement.val(value - 1);
}

$("#fwd-btn").click(() => {
    increaseByOne();
})

$("#back-btn").click(() => {
    decreaseByOne();
})

//$("#back-btn").click(() => {
//    (counter) ? (counter -= 1) : (null); 
//    console.log("The counter is now at: ", counter);
//})