$('a[id^="correct-true_false_unknowns"]').on('click', function(){
  console.log('Click');
  var question_id = $(this).attr('data-id');
  $('#feedback-true_false_unknowns-' + question_id).html('');
  $('.correct-true_false_unknowns-' + question_id).each(function(){
    console.log('true_false_unknowns');
    if( $(this).is(":checked") && $(this).attr('data-correct') != 1 ){
      $('#feedback-true_false_unknowns-' + question_id).append( '<div class="alert alert-danger" role="alert"><strong>' + $(this).attr('data-choice') + '</strong> : ' +  $(this).attr('data-feedback') + '</div>');
    }else if( $(this).is(":checked") && $(this).attr('data-correct') == 1 ){
      $('#feedback-true_false_unknowns-' + question_id).append( '<div class="alert alert-success" role="alert"><strong>' + $(this).attr('data-choice') + '</strong> : ' +  correct_answer + '</div>');
    }
  });
});
