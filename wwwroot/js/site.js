// Write your Javascript code.

$(".isReadBox").change(function(){
    console.log("this works")
    $(this).val(true)
    $(".isReadForm").submit();
    console.log($(this).val());
});



