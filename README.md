# BouncyQubits
A game of life like program where Qubits are created to destroyed based on a set of rules
The number on each Qubit is it's super position state. A 50 means the Qubit has a 50% chance of collapsing
to a One and Zero. A 60 means there is a 60% chance of collapsing to a One and a 40% chance of collapsing
to a Zero. When two Qubits collide into each other, their states collapse. There super position state is then 
changed based on this logic:</br>
<hr>
Qubit1  => One  and Qubit2 => One   Both increase by 10. </br>
Qubit1 =>One and Qubit2 => Zero  Qubit1 decreases 5 and Qubit2 increases 5</br>
Qubit1 =>Zero and Qubit2 => One  Qubit1 increases 5 and Qubit2 decreases 5</br>
Qubit1 => Zero and Qubit2=> Zero Both decease by 10. </br>
<hr>
If a Qubit drops to Zero it is removed from the board. </br>
If a Qubit raises to 100 it creates a new Qubit and both are set to 50.</br>
When a Qubit is created it is entanled with the Qubit that created it. </br>
If either entanled Qubit collide and collapse, the state it collapsed to is </br>
transfered to the entangled Qubit. So if Qubit1 creates Qubit2 and Qubit1 collapses to a One state</br>
when Qubit2 collides is will also collapse to a One state.</br>
When two Qubits collide their color will change momentarily.</br>
If the Qubit collapses to a One it will turn RED. If it collapses to a Zero it will turn Blue. </br>
When two Qubits are entangled their color will be green. </br>
When one of the entangled Qubits collapses to One, it's entangled Qubit will turn orange</br>
It it collapses to a Zero the other Qubit will turn purple. 

