import Game from "./Game";
import Start from "./Start";
import Finished from "./Finished";
import useTickTackToe from "./useTickTacToe";
const App = () => {
  const game = useTickTackToe();
  return (
    <div className="App">
      {game.status === "created" && <Start handleStart={game.handleStart} />}
      {game.status === "finished" && (
        <Finished name={game.winner} restart={game.handleRestart} />
      )}
      {game.status === "started" && (
        <Game board={game.board} handleClick={game.handleClick} />
      )}
    </div>
  );
};
export default App;