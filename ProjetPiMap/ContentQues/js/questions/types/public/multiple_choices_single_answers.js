$('a[id^="correct-multiple_choices_single_answers"]').on('click', function(){
  console.log('Click');
  var question_id = $(this).attr('data-id');
  $('.correct-multiple_choices_single_answers-' + question_id).each(function(){
    console.log('multiple_choices_single_answers');
    if( $(this).is(":checked") && $(this).attr('data-correct') != 1 ){
      $('#feedback-multiple_choices_single_answers-' + question_id).html( '<div class="alert alert-danger" role="alert"><strong>' + $(this).attr('data-choice') + '</strong> : ' +  $(this).attr('data-feedback') + '</div>');
    }else if( $(this).is(":checked") && $(this).attr('data-correct') == 1 ){
      $('#feedback-multiple_choices_single_answers-' + question_id).html( '<div class="alert alert-success" role="alert"><strong>' + $(this).attr('data-choice') + '</strong> : ' +  $(this).attr('data-feedback') + '</div>');
    }
  });
});
