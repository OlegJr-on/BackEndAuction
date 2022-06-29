import {Lot} from '../components/Lot'

function LotList(props){
    const {lots} = props;

    return <div className="lots"> 
        {lots.map(lot => (
            <Lot key = {lot.Id} {...lot}/>
        ))}
    </div>
}

export {LotList}