$('a[id^="correct-gap_fill_singles"]').on('click', function(){
  console.log('Click gap_fill_singles');
  var question_id = $(this).attr('data-id');
  $('#feedback-gap_fill_singles-' + question_id).html('');
  $('.correct-gap_fill_singles-' + question_id).each(function(){
    console.log('gap_fill_singles');

    console.log( $(this).attr('data-feedback') );

    console.log( typeof $(this).attr('data-feedback') );

    var feedback = ( $(this).attr('data-feedback') != '' ) ? ' : ' + $(this).attr('data-feedback') : ' : Encore un effort...';

    if( $(this).val().trim() == $(this).attr('data-answer') ){
      console.log('Correct');
      $('#feedback-gap_fill_singles-' + question_id).append( '<div class="alert alert-success" role="alert"><strong>' + $(this).val() + '</strong> : ' +  correct_answer + '</div>');
    }else{
      console.log('Incorrect');
      $('#feedback-gap_fill_singles-' + question_id).append( '<div class="alert alert-danger" role="alert"><strong>' + $(this).val() + '</strong>' +  feedback + '</div>');

    }

  });
});
