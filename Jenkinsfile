pipeline{
	agent any
	stages{
		stage('build'){
			when{
				expression{
					env.BRANCHNAME == 'nana'
				}
			}
			steps{
				echo 'building application nana branch...'
			}
		}
		stage('test'){
			steps{
				echo 'testing application ...'
			}
		}

		stage('deploy'){
			steps{
				echo 'deploying application ...'
			}
		}

	}

}