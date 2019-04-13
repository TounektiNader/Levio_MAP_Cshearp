var correctAnswers = 0;

$('body').on('click', '.reset', function () {
  correctAnswers = 0;
  $('#feedback-association_two_columns_pictures_texts-' + $(this).attr('data-questionid')).html('');
  $('.droppable-' + $(this).attr('data-questionid') ).each(function(){
    $(this).droppable( 'enable' );
    $(this).removeClass('correct');
  });
  console.log('Click');
  $('.draggable-' + $(this).attr('data-questionid') ).each(function(){
    console.log('Draggable element');
    $(this).draggable( 'enable' );
    $(this).draggable( 'option', 'revert', true );
    $(this).css({
      'left': $(this).attr('data-originalLeft'),
      'top': $(this).attr('data-origionalTop')
    });
  });
});

$(document).ready(function() {
  $('.image-link').magnificPopup({
      type:'image',
    });
  $('.video-link').magnificPopup({
      type:'iframe',
      iframe: {
        patterns: {
          dailymotion: {

            index: 'dailymotion.com',

            id: function(url) {
                var m = url.match(/^.+dailymotion.com\/(video|hub)\/([^_]+)[^#]*(#video=([^_&]+))?/);
                if (m !== null) {
                    if(m[4] !== undefined) {

                        return m[4];
                    }
                    return m[2];
                }
                return null;
            },

            src: 'http://www.dailymotion.com/embed/video/%id%'

          }
        }
      }
    });
});

$("div[class^='draggableContainer']").each(function(){
  $(this).find('.draggable').shuffle();
});

$(function() {

  $('.draggable').each(function(){
    $(this).attr('data-originalLeft', $(this).css('left'));
    $(this).attr('data-origionalTop', $(this).css('top'));
  });

  $(".reset").click(function(){
    correctAnswers = 0;
    $('.droppable').each(function(){
      $(this).droppable( 'enable' );
      $(this).removeClass('correct');
    });
    console.log('Click');
    $('.draggable').each(function(){
      console.log('Draggable element');
      $(this).draggable( 'enable' );
      $(this).draggable( 'option', 'revert', true );
      $(this).css({
        'left': $(this).attr('data-originalLeft'),
        'top': $(this).attr('data-origionalTop')
      });
    });
  });

  $(".draggable").draggable({
    handle: "div.panel-heading",
    stack: '#elementsPile div',
    cursor: 'move',
    revert: true
  });

  $(".droppable").droppable({
    drop: handleElementDrop,
    hoverClass: 'hovered'
  });

  function handleElementDrop( event, ui ) {
    console.log( $(this) );
    var question_id = $(this).attr( 'data-questionid' );
    console.log( question_id );
    var slotNumber = $(this).attr( 'data-identifier' );
    var elementNumber = ui.draggable.attr( 'data-correct' );

    if ( slotNumber == elementNumber ) {
      $(this).addClass( 'correct' );
      ui.draggable.removeClass( 'list-group-item' );
      ui.draggable.draggable( 'disable' );
      $(this).droppable( 'disable' );
      ui.draggable.position( { of: $(this), my: 'left top', at: 'left top' } );
      ui.draggable.draggable( 'option', 'revert', false );
      correctAnswers++;
    }else{
      $(this).addClass( 'incorrect' );
      var self = $(this);
      setTimeout(function() {
        self.removeClass( 'incorrect' );
      }, 1000);
    }

    if( correctAnswers == ui.draggable.attr( 'data-total' ) ){
      $('#feedback-association_two_columns_texts_texts-' + question_id).html('<div class="alert alert-success" role="alert"><strong>Bravo,</strong> vous avez terminé !</div><a data-questionid="' + question_id + '" class="btn btn-warning reset"><i class="fa fa-history"></i> Recommencer</a>');
      $('#feedback-association_two_columns_pictures_texts-' + question_id).html('<div class="alert alert-success" role="alert"><strong>Bravo,</strong> vous avez terminé !</div><a data-questionid="' + question_id + '" class="btn btn-warning reset"><i class="fa fa-history"></i> Recommencer</a>');
      $('#feedback-association_two_columns_videos_texts-' + question_id).html('<div class="alert alert-success" role="alert"><strong>Bravo,</strong> vous avez terminé !</div><a data-questionid="' + question_id + '" class="btn btn-warning reset"><i class="fa fa-history"></i> Recommencer</a>');
      correctAnswers = 0;
    }

    return false;

  }

});
