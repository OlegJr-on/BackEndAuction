import React from 'react';
import { Link } from 'react-router-dom';

class Congrats extends React.Component{
    render(){
        return <div className='CongratsPage-fragment'>

                <img height='450' width='600' src='https://thumbs.dreamstime.com/b/congratulations-hand-lettering-typography-text-vector-eps-letter-script-wedding-sign-catch-word-art-design-good-scrap-120021980.jpg'/>
                
                <div className='link'>
                    <p className='btn waves-effect waves-light grey darken-2'>
                        <Link to="/">Go to Home </Link>
                    </p>
                </div>

          </div>;
    }
}

export {Congrats}