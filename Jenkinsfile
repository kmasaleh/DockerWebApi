def  getGitChanges(){
	echo 'cecking if code changed ...'
	if(currentBuild.changeSets.size() > 0) {
		echo 'code changed ...'
		return true
	}
	else {
		
		//No changes
		echo 'code did not changed ...'
		return false
	}
}

CODE_CHNAGES = getGitChanges()
pipeline{
	agent any
	stages{
		stage('Init') {
			//when {expression {env.BRANCH_NAME.startsWith("nana")}}
			steps {
				enableContentSecurityPolicyForReport()
				deleteDir()
				// cleanWs()
				echo 'env.BRANCH_START_WTH :  ${env.BRANCH_START_WTH}'
				echo 'initiating application nana branch ... ${env.BRANCH_NAME} build bo ${env.BUILD_NUMBER}'
			}
		}
		stage('build'){
			when{
				expression{
					env.BRANCHNAME == 'nana' && env.CODE_CHNAGES==true
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