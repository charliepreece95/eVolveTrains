/*
Tried to add a scroll to the top feature using Javascript but failed to get it to work

window.onscroll = function() {scrollFunction()};

function scrollFunction() {

  let scrollUp = document.getElementById("arrow");
  let scrollTopBody = document.body.scrollTop();
  let scrollTopElement = document.documentElement.scrollTop();

  scrollUp.addEventListener("click", scrollFunction);

  function scrollFunction(){

  if(scrollTopBody > 20 || scrollTopElement > 20)
  {
    scrollUp.classList.add("show-arrow");
  } 
  else 
  {
    scrollUp.classList.remove("show-arrow");
  }
}

*/

/*From codepen*/
/*Jquery*/
let $arrow = $(".arrow");
$arrow.hide();


$(window).on('scroll', function() {
  if ($(this).scrollTop() > 100) {
    $arrow.fadeIn();
  } else {
    $arrow.fadeOut();
  }
});

$arrow.on('click', function(e) {
  $("html, body").animate({scrollTop: 0}, 500);
});