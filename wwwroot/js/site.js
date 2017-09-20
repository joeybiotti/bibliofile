// Write your Javascript code.

$(".isReadBox").change(function(){
    console.log("this works")
    $(this).val(true)
    $(".isReadForm").submit();
    console.log($(this).val());
});

function checkScroll(){
    var startY = $('.navbar').height() * 2; //The point where the navbar changes in px

    if($(window).scrollTop() > startY){
        $('.navbar').addClass("scrolled");
    }else{
        $('.navbar').removeClass("scrolled");
    }
}

if($('.navbar').length > 0){
    $(window).on("scroll load resize", function(){
        checkScroll();
    });
}
