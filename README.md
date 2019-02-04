# BouncyQubits
A game of life like program where Qubits are created to destroyed based on a set of rules
The number on each Qubit is it's super position state. A 50 means the Qubit has a 50% chance of collapsing
to a One and Zero. A 60 means there is a 60% chance of collapsing to a One and a 40% chance of collapsing
to a Zero. When two Qubits collide into each other, their states collapse. There super position state is then 
changed based on this logic:
Qubit1  => One  and Qubit2 => One   Both increase there positions by 10.  If 50 then now 60
Qubit1 =>One and Qubit2 => Zero  Qubit1 decreases 5 and Qubit2 increases 5
Qubit1 =>Zero and Qubit2 => One  Qubit1 increases 5 and Qubit2 decreases 5
Qubit1 => Zero and Qubit2=> Zero Both decease by 10. 

