var category_id = undefined;

$('a[class^="category-category_classification-"]').on('click', function(){
  $('a[class^="category-category_classification-"]').each(function(){
    $(this).removeClass('btn-warning').removeClass('active');
  });
  $(this).addClass('btn-warning').addClass('active');
  category_id = $(this).attr('data-categoryid');
  console.log( 'category_id : ' + category_id );
});

$('a[class^="word-category_classification-"]').on('click', function(){
  var question_id = $(this).attr('data-questionid');
  console.log( 'choiceid : ' + $(this).attr('data-choiceid') );
  if( $(this).attr('data-choiceid') == category_id ){
    $(this).addClass('animated bounceOut');
    var total_number_words =  $('div.categoryClassificationWordsContainer-' + question_id + ' a').length;
    var words_left = $('div.categoryClassificationWordsContainer-' + question_id + ' a[class$="bounceOut"]').length;
    console.log('words_left : ' + words_left);
    if( total_number_words == words_left ){
      console.log('No words left');
      $('div.categoryClassificationContainer-' + question_id).css('display', 'none');
      $('#feedback-category_classifications-' + question_id).removeClass('hidden').addClass('animated zoomIn');
    }
  }else{
    $(this).addClass('animated shake');
  }
});

$("div[class^='categoryClassificationWordsContainer']").each(function(){
  $(this).find('.btn').shuffle();
});
