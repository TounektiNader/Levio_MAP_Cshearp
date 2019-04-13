$('a[id^="correct-multiple_choices_multiple_answers"]').on('click', function(){
  console.log('Click');
  var question_id = $(this).attr('data-id');
  $('#feedback-multiple_choices_multiple_answers-' + question_id).html('');
  $('.correct-multiple_choices_multiple_answers-' + question_id).each(function(){
    console.log('multiple_choices_multiple_answers');
    if( $(this).is(":checked") && $(this).attr('data-correct') != 1 ){
      console.log('Checked but not correct');
      $('#feedback-multiple_choices_multiple_answers-' + question_id).append( '<div class="alert alert-danger" role="alert"><strong>' + $(this).attr('data-choice') + '</strong> : ' +  $(this).attr('data-feedback') + '</div>');
    }else if( $(this).is(":checked") && $(this).attr('data-correct') == 1 ){
      console.log('Checked and correct');
      $('#feedback-multiple_choices_multiple_answers-' + question_id).append( '<div class="alert alert-success" role="alert"><strong>' + $(this).attr('data-choice') + '</strong> : ' +  $(this).attr('data-feedback') + '</div>');
    }else if( ! $(this).is(":checked") && $(this).attr('data-correct') == 1 ){
      console.log('Not checked but correct');
      $('#feedback-multiple_choices_multiple_answers-' + question_id).append( '<div class="alert alert-warning" role="alert"><strong>' + $(this).attr('data-choice') + '</strong> : Vous auriez dû choisir cette réponse</div>');
    }
  });
});
